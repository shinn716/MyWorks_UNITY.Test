using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour {
	Vector3 spainSpeed = Vector3.zero;
	// Use this for initialization
	void Start () {
		spainSpeed = new Vector3(Random.value, Random.value, Random.value);
		this.transform.Rotate(spainSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y<-5){
			rootScript.score+=10;
			print("Score: " + rootScript.score);
			Destroy(this);
		}
	}
}
