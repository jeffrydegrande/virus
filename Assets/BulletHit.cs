using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {	
		if (coll.gameObject.tag == "BulletCollector") {
			Destroy (this.gameObject);

		}
	}
}
