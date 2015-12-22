using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 150;
	public GameObject projectile;
	public float projectileSpeed = 10;
	public float shotsPerSecond = 1;
	public int scoreValue = 150;
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private Score score;

	void Start () {
		score = GameObject.Find ("Score").GetComponent<Score> ();
	}

	void Update () {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void Fire () {
		GameObject missile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}

	void OnTriggerEnter2D (Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.Hit ();
			if (health <= 0) {
				Die ();
			}
		}
	}
	
	void Die () {
		AudioSource.PlayClipAtPoint (deathSound, transform.position);
		score.scorePoint(scoreValue);
		Destroy (gameObject);
	}
}
