using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed = 12f;
	public float tileSize = 512f;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.left*scrollSpeed*Time.deltaTime);

		if (transform.position.x < -54) { // moved off screen

			float scale = Random.Range (4f, 12f);

			transform.position = startPosition;
			transform.localScale = new Vector3(scale, scale, 0);
		}
	}
}
