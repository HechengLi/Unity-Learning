using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplayt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text> ();
		myText.text = Score.score.ToString ();
		Score.reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
