using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find ("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject ("Defenders");
		}
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		Vector2 spawnPos = SnapToGrid (CalculateWorldPointOfMouseClick ());
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (spawnPos, defender);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	void SpawnDefender (Vector2 spawnPos, GameObject defender)
	{
		GameObject newDef = Instantiate (defender, spawnPos, Quaternion.identity) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		
		return new Vector2 (newX, newY);
	}
	
	Vector2 CalculateWorldPointOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 WeirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (WeirdTriplet);
		
		return worldPos;
	}
}
