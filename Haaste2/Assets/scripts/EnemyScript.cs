using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject spawner;

    private string en_name;
    private int HP = 10;
    private string tavoite = "kivi";
    private int tavoitemaara = 2;

    private void Awake()
    {
        spawner = GameObject.Find("EnemySpawner");
        en_name = gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        spawner.GetComponent<SpawnEnemy>().StartCombat(en_name, HP, tavoite, tavoitemaara);
    }
}
