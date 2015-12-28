using UnityEngine;
using System.Collections;

public class attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between every appearance.")]
	public float seenEverySeconds;
	private float walkSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D () {
		
	}
	
	public void SetSpeed (float speed) {
		walkSpeed = speed;
	}
	
	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
