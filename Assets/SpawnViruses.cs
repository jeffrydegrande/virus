using UnityEngine;
using System.Collections;

public class SpawnViruses : MonoBehaviour {

	public GameObject virus;

	// Use this for initialization
	void Start () {
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn() {
		while (true) {
			yield return new WaitForSeconds(Random.Range (2f, 4f));

			Vector3 p = transform.position;
			p.y = Random.Range (-15f, 19f);

			GameObject clone = (GameObject)Instantiate(virus, p, transform.rotation);
			clone.rigidbody2D.velocity = transform.right * - Random.Range (40f, 60f);
	
		}
	}
}
