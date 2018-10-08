using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public GameObject player;
	public SceneAloitus game_manager;
	// Use this for initialization
	void Start () {
		game_manager = SceneAloitus._singleton;
	}
	
	private void OnTriggerEnter2D(Collider2D coll) {
		var name = coll.gameObject.name;

		if (name == "Player(Clone)"){
			Debug.Log("#1");
			game_manager.sounds[1].Play();
			new WaitForSecondsRealtime(2);
			Destroy(player);
			game_manager.restart(true);
		}
		if (name == "bulletPrefab(Clone)"){
			Debug.Log("#2");
			Destroy(gameObject);
			Destroy(coll.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if (player == null){
			player = GameObject.Find("Player(Clone)");
		}
		if (gameObject != null && player != null){
			Vector3 player_pos = player.transform.position;
			Vector3 ero = transform.position - player_pos;
			ero = ero.normalized;

			if (Vector3.Distance(player_pos, transform.position) <= 7.0f){
				transform.position -= (ero * .7f * Time.deltaTime);
			}
		}
	}
}
