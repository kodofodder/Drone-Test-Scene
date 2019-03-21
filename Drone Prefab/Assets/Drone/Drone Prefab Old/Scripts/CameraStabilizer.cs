﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizer : MonoBehaviour {

	public bool StabilizeCamera = true;

	// Update is called once per frame
	void Update () {
		if (StabilizeCamera) {
			// We take the forward direction of the camera
			Vector3 hf = transform.forward;
			// Cancel the UP direction so that it lies in the horizontal plane
			hf.y = 0;
			// And use this to define the lookat direction of the camera;
			transform.LookAt (transform.position + hf);
		} else {
			transform.rotation = transform.parent.rotation;
		}
	}
}
