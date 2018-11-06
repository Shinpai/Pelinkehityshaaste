using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject spawner, CombatUI;

    private string en_name;
    private Animator enemyAnimator;
    public int HP { get; set; }
    public float moveSpeed;
    public int damage;
    public List<string> tavoite;

    private void Awake()
    {
        CombatUI = GameObject.Find("CombatUICanvas");
        spawner = GameObject.Find("EnemySpawner");
        enemyAnimator = GetComponent<Animator>();
        en_name = gameObject.name;
        if (en_name == "possum(Clone)")
        {
            damage = 2;
            HP = 5;
        }            
        else if (en_name == "eagle(Clone)")
        {
            damage = 3;
            HP = 7;
        }
    }
    
    private void Update()
    {
        if (CombatUI.transform.position.z == -10)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void killThis()
    {
        enemyAnimator.SetTrigger("DeathTrigger");
        Debug.Log("animaatio?");
    }

    public void Attack()
    {
        enemyAnimator.SetTrigger("AttackTrigger");
    }

    private void OnTriggerEnter(Collider other)
    {
        spawner.GetComponent<SpawnEnemy>().StartCombat(en_name, HP, tavoite);
    }
}
