using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sketch : MonoBehaviour {

    public GameObject myPrefab;
	// Use this for initialization
	void Start () {
        int totalCubes = 12;
        float totalDistance =2.2f;

        //Linnear 
        //for (int i = 0; i < totalCubes; i++)
        //{
        //    float prec = i / (float)totalCubes;
        //    float z = prec * totalDistance;
        //    float y = 5.0f/3.0f* 4.0f;
        //    float x = 0.0f;

        //    var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
        //    newCube.GetComponent<myCube>().setSize(1.0f - prec);
        //    newCube.GetComponent<myCube>().rotateSpeed = (0);
        //}


        //Sin
        for (int i = 0; i < totalCubes; i++)
        {
            float prec = i / (float)totalCubes;
            float sin = Mathf.Sin(prec * Mathf.PI / 2);
            float x = 1.5f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<myCube>().setSize((1.0f - prec) * 0.5f);
            newCube.GetComponent<myCube>().rotateSpeed = (0.2f + (prec))*3;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
