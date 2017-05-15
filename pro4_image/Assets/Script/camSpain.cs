using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSpain : MonoBehaviour {
	public float spainSpeed = .15f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(Vector3.zero, Vector3.up, spainSpeed);
		this.transform.LookAt(Vector3.zero);
	}
}
