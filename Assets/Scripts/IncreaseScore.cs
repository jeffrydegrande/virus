using UnityEngine;
using System.Collections;

public class IncreaseScore : MonoBehaviour {

	int theScore = 0;


	void Increase( int score ) {
		theScore += score;

		this.guiText.text = "SCORE: " + theScore;
	}
}
