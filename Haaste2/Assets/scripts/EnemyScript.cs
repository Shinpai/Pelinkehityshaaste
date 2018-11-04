using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject spawner, CombatUI;

    private string en_name;
    public int HP { get; set; }
    public float moveSpeed;
    public int damage;
    private string tavoite;
    private int tavoitemaara = 2;    

    private void Awake()
    {
        CombatUI = GameObject.Find("CombatUICanvas");
        spawner = GameObject.Find("EnemySpawner");
        en_name = gameObject.name;
        if (en_name == "possum(Clone)")
        {
            tavoite = "Kivi";
            damage = 2;
            HP = 5;
        }            
        else if (en_name == "eagle(Clone)")
        {
            tavoite = "Paperi";
            damage = 3;
            HP = 7;
        }
    }

    public string[] getTavoite()
    {
        string[] tav = new string[tavoitemaara];
        for (int i = 0; i < tav.Length; i++)
        {
            tav[i] = tavoite;
        }
        return tav;
    }

    private void Update()
    {
        if (CombatUI.transform.position.z == -10)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawner.GetComponent<SpawnEnemy>().StartCombat(en_name, HP, tavoite, tavoitemaara);
    }
}
