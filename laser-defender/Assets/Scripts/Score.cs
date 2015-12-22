using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score = 0;
	
	private Text myText;
	
	void Start () {
		myText = GetComponent<Text> ();
		reset();
	}
	
	public void scorePoint (int points) {
		score += points;
		myText.text = score.ToString ();
	}
	
	public static void reset () {
		score = 0;
	}
}
