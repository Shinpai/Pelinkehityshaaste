using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRolling : MonoBehaviour {

    private GameObject pool;
	// Use this for initialization
	void Start () {
        pool = GameObject.Find("DicePool");
    }
	
	public void RollAll()
    {
        if (pool.transform.childCount == 0)
            Debug.Log("ei noppia");
        foreach (Transform dice in pool.transform)
        {
            var result = dice.GetComponent<Dice>().RollMe();
            Debug.Log(result);
        }
    }
}
