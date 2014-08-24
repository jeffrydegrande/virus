using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	// private GameObject player;
	public Rigidbody2D projectile;
	public float projectileSpeed = 120f;
	
	void Update () {
		if (Input.GetButtonDown("Fire")) {
			Rigidbody2D bulletClone = (Rigidbody2D)Instantiate (projectile, transform.position, transform.rotation);
			bulletClone.velocity = transform.right * projectileSpeed;
		}
	}
}
