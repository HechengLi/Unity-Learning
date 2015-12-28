using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		attacker attacker = collider.gameObject.GetComponent<attacker> ();
		Health health = collider.gameObject.GetComponent<Health> ();
		
		if (attacker && health) {
			health.DealDamage (damage);
			Destroy (gameObject);
		}
	}
}
