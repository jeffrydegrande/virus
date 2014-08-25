using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	public float hitpoints = 3;
	public AudioClip monsterHit;
	public AudioClip monsterExplodes;
	public GameObject game;
	GameObject score;


	public Animator anim;

	// Use this for initialization
	void Start () {
		game = GameObject.Find("Game");
		score = GameObject.Find ("Score");
	}


	public void OnTriggerEnter2D(Collider2D collider) {
		if ( collider.gameObject.tag == "VirusCollector" ) {
			Destroy (gameObject );
		} else {
		
			// player collision detecction here.
			//	Debug.Log ( collider.gameObject.tag );
		}
	}


	public void ApplyDamage(int value) {
		hitpoints -= value;
		game.audio.PlayOneShot (monsterHit);

		if (anim) {
			anim.SetBool ("Hit", true);
		}

		if (hitpoints <= 0) {
			Die();
		}
	}


	void Die()
	{
		score.SendMessage("Increase", 1);
		anim.SetBool("Dead", true);
		rigidbody2D.velocity = Vector3.zero;
		game.audio.PlayOneShot(monsterExplodes);
		StartCoroutine(Cleanup ());
	}

	IEnumerator Cleanup() {
		yield return new WaitForSeconds(0.4f);
		Destroy(gameObject);
	}
}

