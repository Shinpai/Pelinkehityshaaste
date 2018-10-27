using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour {

    public GameObject possumPrefab, CombatUI, BoxOfDice, BagOfDice, dicePrefab, poGO;
    public float moveSpeed;
    private bool win_flag;
    GameObject enemySpawner, enemyGO;

    private void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner");
        BoxOfDice = GameObject.Find("DiceBox");
        BagOfDice = GameObject.Find("DiceBag");
        poGO = GameObject.Find("Character");
    }

    public void AddDice(Dice die)
    {
        var grid = BoxOfDice.GetComponent<Grid>();
        GameObject diceGO = Instantiate<GameObject>(dicePrefab);
        diceGO.transform.SetParent(BoxOfDice.transform.GetChild(0).transform);
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
        StartCoroutine(DoCombatWith(en_name));
    }

    private IEnumerator DoCombatWith(string en_name)
    {
        GameObject enemy = GameObject.Find(en_name);
        yield return new WaitForSecondsRealtime(2);
        if (CheckPlayerAndOpponent(poGO, enemy) == 1)
        {
            // if win
            Debug.Log("#Combat end");
            Destroy(enemy);
            Time.timeScale = 1.0f;
            CombatUI.SetActive(false);
        }
        else if (CheckPlayerAndOpponent(poGO, enemy) == 0)
        {
            // lose
            SceneManager.LoadScene(0);
        }
        DoCombatWith(en_name);        
    }

    private int CheckPlayerAndOpponent(GameObject pla, GameObject enemy)
    {
        if (pla.GetComponent<CharacterScript>().HP < 0)
            return 0;
        else if (enemy.GetComponent<EnemyScript>().HP < 0)
            return 1;
        return -1;
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
