using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    public int max_HP { get; private set; }
    public int HP { get; set; }
    public int damage;

    private Animator mator;

    private void Start()
    {
        mator = GetComponent<Animator>();
        max_HP = 10;
        HP = 10;
        damage = 2;
    }

    public void Attack()
    {
        Debug.Log("atak");
        mator.SetTrigger("AttackTrigger");
    }
}
