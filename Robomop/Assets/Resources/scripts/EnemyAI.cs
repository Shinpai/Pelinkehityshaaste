using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public GameObject player;
	public SceneAloitus _singleton;
	// Use this for initialization
	void Start () {
		_singleton = SceneAloitus._singleton;
	}
	
	private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Player(Clone)"){
			Destroy(player);
			_singleton.restart();
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
				transform.position -= (ero * .5f * Time.deltaTime);
			}
		}
	}
}
