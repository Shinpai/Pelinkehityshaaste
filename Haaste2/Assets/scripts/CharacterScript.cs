using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("char");
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("char");
        Debug.Log(other.gameObject.name);
    }
}
