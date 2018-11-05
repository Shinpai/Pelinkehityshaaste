using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SpawnEnemy : MonoBehaviour {

    public GameObject possumPrefab, eaglePrefab, CombatUI, BoxOfDice, BagOfDice, dicePrefab, poGO;
    private Text phpgo, ehpgo;
    private Slider pslider, eslider;
    private bool win_flag;
    public string _en_name;
    private GameObject enemySpawner, enemyGO;
    public bool rolled = false;

    private void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner");
        BoxOfDice = GameObject.Find("DiceBox");
        BagOfDice = GameObject.Find("DiceBag");
        poGO = GameObject.Find("Character");
        CombatUI = GameObject.Find("CombatUICanvas");
        phpgo = GameObject.Find("PlayerHPText").GetComponent<Text>();
        ehpgo = GameObject.Find("EnemyHPText").GetComponent<Text>();
        pslider = GameObject.Find("PlayerSlider").GetComponent<Slider>();
        eslider = GameObject.Find("EnemySlider").GetComponent<Slider>();
        pslider.maxValue = poGO.GetComponent<CharacterScript>().max_HP;
        
    }

    private int enemy_counter;
    private void Update()
    {
        // update combatui
        phpgo.text = string.Format("{0}", poGO.GetComponent<CharacterScript>().HP);
        pslider.value = poGO.GetComponent<CharacterScript>().HP;
        if (enemyGO)
        {
            ehpgo.text = string.Format("{0}", enemyGO.GetComponent<EnemyScript>().HP);
            eslider.value = enemyGO.GetComponent<EnemyScript>().HP;            
        }
        else if(enemyGO == null)
        {
            CreateAndSpawn(enemy_counter);
        }
    }

    /// <summary>
    /// Instantioi otukset
    /// </summary>
    public void CreateAndSpawn(int counter)
    {
        string[] enemies = new string[] { "possum", "eagle" };
        int enemytype = UnityEngine.Random.Range(1, enemies.Length + 1);
        Debug.Log(string.Format("Enemy of type {0} spawned", enemytype));

        if (enemytype == 1)
        {
            enemyGO = Instantiate<GameObject>(possumPrefab);
            enemyGO.transform.SetParent(enemySpawner.transform);
            enemyGO.transform.position = enemySpawner.transform.position;
        }
        else if (enemytype == 2)
        {
            enemyGO = Instantiate<GameObject>(eaglePrefab);
            enemyGO.transform.SetParent(enemySpawner.transform);
            enemyGO.transform.position = new Vector3(enemySpawner.transform.position.x, 5, enemySpawner.transform.position.z);
        }

        int[] skaalaus = new int[] { 1,1,2,2,2,3,3,3,3,3,4,4,4,5,5,6 };
        string[] KPS = new string[] { "Kivi", "Sakset", "Paperi" };
        for (int i = 0; i < skaalaus[enemy_counter]; i++)
        {
            var next_ind = UnityEngine.Random.Range(0, 3);
            enemyGO.GetComponent<EnemyScript>().tavoite.Add(KPS[next_ind]);
        }
        eslider.maxValue = enemyGO.GetComponent<EnemyScript>().HP;
        enemy_counter++;
    }

    /// <summary>
    /// Instantioi nopat
    /// </summary>
    /// <param name="die"></param>
    public void AddDice(Dice die)
    {
        var grid = BoxOfDice.GetComponent<Grid>();
        GameObject diceGO = Instantiate<GameObject>(dicePrefab);
        diceGO.transform.SetParent(BoxOfDice.transform.GetChild(0).transform);
    }

    /// <summary>
    /// combati alustukset
    /// </summary>
    /// <param name="en_name"></param>
    /// <param name="HP"></param>
    /// <param name="tavoite"></param>
    /// <param name="tavoitemaara"></param>
    internal void StartCombat(string en_name, int HP, List<string> tavoite)
    {
        Debug.Log(string.Format("#Combat start with : {0}, {1}, {2}", en_name, HP, tavoite));
        CombatUI.transform.Translate(0, 0, 10);
        //GameObject enemy = GameObject.Find(en_name);
        GameObject enemy = enemyGO;
        // tavoite setup
        var pool = CombatUI.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        // poistetaan vanhat ensin
        foreach (Transform child in pool.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (string item in tavoite)
        {
            Debug.Log(item);
            var go = Instantiate<GameObject>(dicePrefab);
            go.transform.SetParent(pool.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
            go.GetComponent<Dice>().tulos = item;
            go.GetComponent<Dice>().tavoite_flag = true;
        }
    }

    /// <summary>
    /// Itse combat sykli. Tarkastaa onko combat loppu
    /// </summary>
    /// <param name="en_name"></param>
    /// <returns></returns>
    public IEnumerator DoCombatWith(string en_name)
    {
        Button roll = GameObject.Find("RollButton").GetComponent<Button>();
        roll.interactable = false;

        _en_name = en_name;
        GameObject enemy = GameObject.Find(en_name);
        int tulos = 0;
        var pool = GameObject.Find("DicePool").transform;
        var target = GameObject.Find("TargetPool").transform;

        foreach (Transform child in pool)
        {
            if (target.GetChild(0).GetComponent<Dice>().tulos == child.GetComponent<Dice>().tulos)
                tulos += 1;
        }
        Debug.Log(tulos + "/" + target.childCount);
        yield return new WaitForSeconds(1);

        if (tulos < target.childCount)
        {
            Debug.Log("player damaged");
            var dmg = enemyGO.GetComponent<EnemyScript>().damage;
            poGO.GetComponent<CharacterScript>().HP -= dmg;
        }
        else if(tulos >= target.childCount)
        {
            Debug.Log("enemy damaged");
            var dmg = poGO.GetComponent<CharacterScript>().damage;
            enemyGO.GetComponent<EnemyScript>().HP -= dmg;
        }
        
        var checker = CheckPlayerAndOpponent();
        if (checker == 1)
        {
            // if win            

            yield return new WaitForSeconds(1);
            Debug.Log("#Combat end");
            poGO.GetComponent<CharacterScript>().HP = poGO.GetComponent<CharacterScript>().max_HP;
            Destroy(enemyGO);
            CombatUI.transform.Translate(0, 0, -10);
            
        }
        else if (checker == 0)
        {
            // lose            
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(0);
        }        
        
        yield return new WaitForSeconds(1);
        Debug.Log("Combat stopped");
        StopCoroutine(DoCombatWith(en_name));
        roll.interactable = true;
    }

    /// <summary>
    /// Tarkistaa combattia varten HP:t ja onko tarvetta lopettaa
    /// </summary>
    /// <param name="pla"></param>
    /// <param name="enemy"></param>
    /// <returns></returns>
    private int CheckPlayerAndOpponent()
    {
        var pla = poGO;
        var enemy = enemyGO;
        Debug.Log(string.Format("checked : {0}", enemy.name));
        if (pla.GetComponent<CharacterScript>().HP <= 0)
            return 0;
        else if (enemy.GetComponent<EnemyScript>().HP <= 0)
            return 1;
        return -1;
    }
}
