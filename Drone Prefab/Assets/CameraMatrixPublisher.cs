using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMatrixPublisher : MonoBehaviour {
	public Camera cam;
	// Use this for initialization
	void Start () {
		Debug.Log(cam.projectionMatrix);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
