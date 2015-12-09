using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {
	int max;
	int min;
	int guess;
	bool finish;
	int counter;
	
	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		guess = 500;
		counter = 1;
		finish = false;
		
		print ("Welcome to Number Wizard");
		print ("Pick a number in your head, but don't tell me!");
		
		print ("The highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
		print ("Is the number higher or lower than " + guess);
		print ("Up = higher, down = lower, return = equal");
		
		max++;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = guess;
			NextGuess ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = guess;
			NextGuess ();
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			print ("I win");
			print ("I took " + counter + " guesses to win");
			finish = true;
			print ("Restart? Y/N");
		}
		if (finish) {
			if (Input.GetKeyDown (KeyCode.Y)) {
				print ("=================================");
				StartGame ();
			} else if (Input.GetKeyDown (KeyCode.N)) {
				Application.Quit ();
			}
		}
	}
	
	void NextGuess () {
		guess = (max + min)/2;
		counter++;
		print ("Is the number higher or lower than " + guess);
		print ("Up = higher, down = lower, return = equal");
	}
}
