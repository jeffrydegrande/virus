using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	// private GameObject player;
	public Rigidbody2D projectile;
	public float projectileSpeed = 120f;


	// Use this for initialization
	void Start () {
		// player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")) {
			Rigidbody2D bulletClone = (Rigidbody2D)Instantiate (projectile, transform.position, transform.rotation);
			bulletClone.velocity = transform.right * projectileSpeed;
		}
	}
}
