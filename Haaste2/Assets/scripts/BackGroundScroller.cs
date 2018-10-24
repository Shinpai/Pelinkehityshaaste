using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour {

    Material mat;
    Vector2 offset;

    public float xVelocity, yVelocity;    

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
        offset = new Vector2(xVelocity, yVelocity);
	}
	
	// Update is called once per frame
	void Update () {
        mat.mainTextureOffset += offset * Time.deltaTime;
	}
}
