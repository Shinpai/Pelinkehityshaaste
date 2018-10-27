using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour {

    Material mat;
    Vector2 offset;

    public float xVelocity, yVelocity;

    // Use this for initialization
    void Start () {
        mat = GetComponent<MeshRenderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        offset = new Vector2(xVelocity, yVelocity);
        mat.mainTextureOffset += offset * Time.deltaTime;
	}
}
