using UnityEngine;
using System.Collections;

public class MainBackgroundScroller : MonoBehaviour {

	public float scrollSpeed = 12f;
	private Vector3 startPosition;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.left*scrollSpeed*Time.deltaTime);
		
		if (transform.position.x < -54) { // moved off screen
			transform.position = startPosition;
		}
	}
}
