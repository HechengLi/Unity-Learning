using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	public Vector2 touchVelocity = new Vector2 (0, 0);

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//Lock ball to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//Launch ball on mouse click
			if (Input.GetMouseButton(0)) {
				Vector2 initialVelocity = new Vector2 (0, 10f);
				this.rigidbody2D.velocity = initialVelocity;
				hasStarted = true;
			}
		} else {
			//this.rigidbody2D.velocity = this.rigidbody2D.velocity + touchVelocity;
			//touchVelocity = new Vector2 (0, 0);
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
