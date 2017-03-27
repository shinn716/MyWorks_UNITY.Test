using UnityEngine;
using System.Collections;

public class pickUpController : MonoBehaviour {

	public float RotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3(0,0,RotateSpeed*Time.deltaTime));
	}
}
