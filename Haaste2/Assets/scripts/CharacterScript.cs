using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    public int max_HP { get; private set; }
    public int HP { get; set; }

    private void Start()
    {
        max_HP = 10;
    }
}
