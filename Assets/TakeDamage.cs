using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	public float hitpoints = 3;
	public AudioClip monsterHit;
	public AudioClip monsterExplodes;
	public GameObject game;

	// Use this for initialization
	void Start () {
		game = GameObject.Find("Game");
	}


	public void ApplyDamage(int value) {
		hitpoints -= value;
		game.audio.PlayOneShot (monsterHit);

		if (hitpoints <= 0) {
			Die();
		}
	}


	void Die()
	{
		Destroy(gameObject);
		game.audio.PlayOneShot(monsterExplodes);
	}
}

