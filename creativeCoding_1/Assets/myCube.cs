using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCube : MonoBehaviour {

    //private float size = 1;
    public float rotateSpeed = 1.0f;
    public Vector3 spainSpeed = Vector3.zero;
    public Vector3 spainAxis = new Vector3(0.0f,1.0f,0);
    public GameObject prefab;

	// Use this for initialization
	void Start () {
        //size = Mathf.Round(Random.Range(1.5f, 3));
        //this.transform.position = new Vector3(0,5,3);
        //setSize(1.5f);
        spainSpeed = new Vector3(Random.value, Random.value, Random.value);
        //spainSpeed = new Vector3(1.0f, 1.0f, 1.0f);
        spainAxis = Vector3.up;
        spainAxis.x = (Random.value - Random.value)*0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(spainSpeed);
        this.transform.RotateAround(Vector3.zero, spainAxis, rotateSpeed);
	}

    public void setSize(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
    }
}
