using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}
	
	void Spawn (GameObject myGameObject) {
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn (GameObject attackerGameObject) {
		attacker attack = attackerGameObject.GetComponent<attacker> (); 
		float meanSpawnDelay = attack.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawnrate capped by frame rate");
		}
		
		float threashold = spawnsPerSecond * Time.deltaTime / 5;
		return Random.value < threashold;
	}
}
