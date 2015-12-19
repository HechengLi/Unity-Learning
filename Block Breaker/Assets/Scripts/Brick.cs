using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;

	private int maxHits;
	private int timesHit = 0;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		maxHits = hitSprites.Length + 1;
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (isBreakable) {
			AudioSource.PlayClipAtPoint (crack, transform.position);
			print (this.tag);
			HandleHits ();
		}
	}
	
	void HandleHits () {
		timesHit++;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
}
