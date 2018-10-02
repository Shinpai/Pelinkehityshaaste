using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Skybox sb;
	// Use this for initialization
	void Start () {		
		this.transform.position = new Vector3(1,-2.5f,-8);
		this.transform.rotation = Quaternion.Euler(new Vector3(5, -5, 0));
	}

	// Update is called once per frame
	void Update () {

	}
}
