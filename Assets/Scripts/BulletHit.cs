using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {	
		if (coll.gameObject.tag == "BulletCollector") {
			Destroy (this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy" ) {
			Destroy (this.gameObject);
			collider.gameObject.SendMessage ("ApplyDamage", 1);
		}
	}
}
