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
			score.SendMessage("Increase", 1);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy" ) {
			Destroy (this.gameObject);
			collider.gameObject.SendMessage ("ApplyDamage", 1);
		}
	}
}
