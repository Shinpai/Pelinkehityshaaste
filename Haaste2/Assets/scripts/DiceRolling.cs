using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRolling : MonoBehaviour {

    private GameObject pool;
    private GameObject enemySpawner;
	// Use this for initialization
	void Start () {
        pool = GameObject.Find("DicePool");
        enemySpawner = GameObject.Find("EnemySpawner");
    }
	
	public void RollAll()
    {
        if (pool.transform.childCount == 0)
            Debug.Log("ei noppia");
        foreach (Transform dice in pool.transform)
        {
            var result = dice.GetComponent<Dice>().RollMe();
        }

        Debug.Log("Combat restarted");
        var _name = enemySpawner.GetComponent<SpawnEnemy>()._en_name;
        enemySpawner.GetComponent<SpawnEnemy>().StartCoroutine(enemySpawner.GetComponent<SpawnEnemy>().DoCombatWith(_name));
    }
}
