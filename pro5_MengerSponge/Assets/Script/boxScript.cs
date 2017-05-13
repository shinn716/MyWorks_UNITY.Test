using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour {

	GameObject myPrefab;
	public float f_r;
	Vector3 v_pos;
	public Vector3 spainSpeed = Vector3.zero;
	public Vector3 spainAxis = new Vector3(0.0f,1.0f,0);
	public float rotateSpeed = 0.5f;
	void Start(){
		spainSpeed = new Vector3(0, 0, 0.5f);
        spainAxis = Vector3.up;
        spainAxis.x = (Random.value - Random.value)*0.1f;
	}

	public void init(GameObject tmpGameObject, Vector3 tmpPos, float tmpR){
		print("boxScript start");

		myPrefab = tmpGameObject;
		f_r = tmpR;
		v_pos = tmpPos;

	}

	public List<GameObject> generate(List<GameObject> boxes){

		// boxes = new List<GameObject>();

		for(int x=-1; x<2; x++){
			for(int y=-1; y<2; y++){
				for(int z=-1; z<2; z++){
					
					float newR=f_r;			// f_r/3
					float px = v_pos.x+newR*x;
					float py = v_pos.y+newR*y;
					float pz = v_pos.z+newR*z;
					
					float sum =  Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z);

					if(sum<=1) {
						GameObject newBox;
						newBox = Instantiate(myPrefab, new Vector3(px, py, pz), Quaternion.identity);
						newBox.transform.localScale = new Vector3(newR, newR, newR);
						boxes.Add(newBox);
					}

				}
			}
		}
		return boxes;
	}
	
	void Update () {
	

		// this.transform.RotateAround(Vector3.zero, spainAxis, rotateSpeed);
		
	}


}
