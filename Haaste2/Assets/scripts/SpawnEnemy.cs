using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject possumPrefab, CombatUI;
    public float moveSpeed;
    GameObject enemySpawner, enemyGO;

    private void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner");
    }

    private void Update()
    {   
        if (enemyGO)
        {
            enemyGO.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    internal void StartCombat(string en_name, int HP, string tavoite, int tavoitemaara)
    {
        Debug.Log(string.Format("#Combat start with : {0}, {1}, {2}, {3}", en_name, HP, tavoite, tavoitemaara));
        Time.timeScale = 0;
        CombatUI.SetActive(true);

        // do combat
        StartCoroutine(WaitAndUnpause(en_name));
    }

    private IEnumerator WaitAndUnpause(string en_name)
    {
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1.0f;
        CombatUI.SetActive(false);
        // if win
        Debug.Log("#Combat end");
        GameObject enemy = GameObject.Find(en_name);
        Destroy(enemy);
    }

    public void CreateAndSpawn(string enemytype)
    {
        if (enemytype == "possum")
        {
            enemyGO = Instantiate<GameObject>(possumPrefab);
            enemyGO.transform.SetParent(enemySpawner.transform);
            enemyGO.transform.position = enemySpawner.transform.position;
        }
    }
}
