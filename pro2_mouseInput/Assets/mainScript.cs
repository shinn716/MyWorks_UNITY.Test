using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] g_btn = new GameObject[20];
	Vector3[] pos = new Vector3[20];
	Vector3[] speed = new Vector3[20];


	public float speedValue = 0.8f;
	// public Texture aTexture;

	public static bool b_Clicked=false;
	int stageWidth=791, stageHeight=445;
 	void Start () {

		// GUI.DrawTexture(new Rect(321, 180, 642, 361), aTexture, ScaleMode.ScaleToFit, true, 10.0F);

		for(int i=0; i<g_btn.Length; i++){
			speed[i] = new Vector3(Random.Range(speedValue-.2f, speedValue), 0, 0);

            float prec = i / (float) g_btn.Length;
            float sin = Mathf.Sin(prec * Mathf.PI / 2);
			float x = sin * 800;
			float y = sin * 445;

			pos[i] = new Vector3(x, y, 0);
			// pos[i] = new Vector3(Random.Range(0, 700), Random.Range(0+40, 370-40), 0);

			// print(i + " pos: "+pos[i] + " speed: "+ speed[i]);
			g_btn[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			float rotateAngle = Random.Range(-10,10)*Random.value;
			// print(i +" "+ rotateAngle);
			g_btn[i].transform.Rotate(new Vector3(0, 0, rotateAngle));
		}
	}	
	void Update () {

		if(b_Clicked) {

		} else {
			for(int i=0; i<g_btn.Length; i++){
				pos[i]-=speed[i];
				g_btn[i].transform.position = pos[i];

				if(pos[i].x<-80){
	            	// float prec = i / (float) g_btn.Length;
	            	// float sin = Mathf.Sin(prec * Mathf.PI / 2);
					// float y = sin * 370;				
					pos[i] = new Vector3(stageWidth+80, Random.Range(0, stageHeight-40), 0);
				}
			}
		}



	}

}
