using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	GameObject score;

	void Start() {
		score = GameObject.Find ("Score");
	}

	void OnCollisionEnter2D(Collision2D coll) {	
		if (coll.gameObject.tag == "BulletCollector") {
			Destroy (this.gameObject);

			// just fake the score for now

			score.SendMessage("Increase", 1);
		}
	}
}
