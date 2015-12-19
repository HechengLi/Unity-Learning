using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public float mousePosInBlocks;
	public Vector3 paddlePos;
	public float speed = 0f;
	private float curPosition, prevPosition;
	private Ball ball;
	// Use this for initialization
	void Start () {
		curPosition = this.transform.position.x;
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		paddlePos = new Vector3 (0.5f, this.transform.position.y ,0f);
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
		prevPosition = curPosition;
		curPosition = this.transform.position.x;
		speed = (curPosition - prevPosition)*9f;
		speed = Mathf.Clamp(speed, -20f, 20f);
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		ball.touchVelocity.x = ball.touchVelocity.x + speed*2;
	}
}
