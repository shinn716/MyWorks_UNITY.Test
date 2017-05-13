using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour {
	public float spainSpeed = .15f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(Vector3.zero, Vector3.up, spainSpeed);
		this.transform.LookAt(Vector3.zero);		
	}
}
