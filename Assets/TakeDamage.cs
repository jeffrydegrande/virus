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
		Destroy(gameObject);
		game.audio.PlayOneShot(monsterExplodes);
	}
}

