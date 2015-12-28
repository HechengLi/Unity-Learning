using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;
	
	public void DealDamage (float damage) {
		if ((health -= damage) > 0) {
			health -= damage;
		} else {
			Destroy (gameObject);
		}
	}
	
	public void DestoryObject () {
		Destroy (gameObject);
	}
}
