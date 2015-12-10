using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	
	int MaxGuessesAllowed;
	
	public Text text;
	
	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		guess = Random.Range (min, max+1);
		MaxGuessesAllowed = 5;
		text.text = guess.ToString ();
	}
	
	public void GuessHigher () {
		min = guess;
		min++;
		NextGuess ();
	}
	
	public void GuessLower () {
		max = guess;
		max--;
		NextGuess ();
	}
	
	void NextGuess () {
		guess = Random.Range (min, max+1);
		MaxGuessesAllowed--;
		if (MaxGuessesAllowed <= 0) {
			Application.LoadLevel ("Win");
		}
		text.text = guess.ToString ();
	}
}
