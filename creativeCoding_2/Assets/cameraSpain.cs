using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSpain : MonoBehaviour {

    public float spainSpeed = .15f;
    void Start () {
		// Debug.Log("Hello");
	}
	
	void Update () {
        this.transform.RotateAround(Vector3.zero, Vector3.up, spainSpeed);
        this.transform.LookAt(Vector3.zero);
	}
}
