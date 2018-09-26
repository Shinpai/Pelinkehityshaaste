using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {		
		this.transform.position = new Vector3(3,-2,-7);
		this.transform.rotation = Quaternion.Euler(new Vector3(10, -10, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
