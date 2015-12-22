using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float speed;
	public float spawnDelay;
	
	private bool movingRight = true;
	private float xmax;
	private float xmin;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.x - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
		xmax = rightBoundary.x;
		xmin = leftBoundary.x;
		
		SpawnUntilFull ();
	}
	
	void SpawnEnemies () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	void SpawnUntilFull () {
		Transform freePosition = NextFreePosition ();
		if (freePosition){
			GameObject enemy = Instantiate (enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
	
	public void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, new Vector3(width, height, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.position += Vector3.right*speed*Time.deltaTime;
		} else {
			transform.position += Vector3.left*speed*Time.deltaTime;
		}
		
		float rightEdgeOfFormation = transform.position.x + width/2;
		float leftEdgeOfFormation = transform.position.x - width/2;
		if (rightEdgeOfFormation >= xmax) {
			movingRight = false;
		} else if (leftEdgeOfFormation <= xmin) {
			movingRight = true;
		}
		
		if (AllMembersDead ()) {
			SpawnUntilFull ();
		}
	}
	
	Transform NextFreePosition () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount <= 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}
	
	bool AllMembersDead () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
