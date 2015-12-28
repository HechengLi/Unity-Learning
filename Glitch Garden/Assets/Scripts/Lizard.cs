using UnityEngine;
using System.Collections;

[RequireComponent (typeof (attacker))]
public class Lizard : MonoBehaviour {
	
	private Animator animator;
	private attacker att;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		att = GetComponent<attacker> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;
		
		if (!obj.GetComponent<defender> ()) {
			return;
		}
		
		animator.SetBool ("isAttacking", true);
		att.Attack (obj);
	}
}
