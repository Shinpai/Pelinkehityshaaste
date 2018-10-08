using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	public SceneAloitus game_manager;
	// Use this for initialization
	void Start () {
		game_manager = SceneAloitus._singleton;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Player(Clone)"){
			Debug.Log("#3");
			return;
		}
		if (col.gameObject.name == "Enemy(Clone)"){
			Debug.Log("#4");
			game_manager.sounds[0].Play();
			game_manager.xp += 20;	
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
}
