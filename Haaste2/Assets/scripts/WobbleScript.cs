using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleScript : MonoBehaviour {

    public float waitTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(Wobble());
	}

    private IEnumerator Wobble()
    {
        float wobble_amount = .01f;
        yield return new WaitForSeconds(waitTime);
        transform.Translate(new Vector3(wobble_amount, 0, 0));
        yield return new WaitForSeconds(waitTime);
        transform.Translate(new Vector3(0, -wobble_amount, 0));
        yield return new WaitForSeconds(waitTime);
        transform.Translate(new Vector3(0, wobble_amount, 0));
        yield return new WaitForSeconds(waitTime);
        transform.Translate(new Vector3(-wobble_amount, 0, 0));

        StartCoroutine(Wobble());
    }
}
