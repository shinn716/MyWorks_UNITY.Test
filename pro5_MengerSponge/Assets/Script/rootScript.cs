using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootScript : MonoBehaviour {

	public GameObject myPrefab;
	List<GameObject> l_sponge;
	// boxScript mybox = new boxScript();
	Vector3 v_pos;
	float f_size=3f;
	int i_test=0;
	float f_value=3f;
	void Start () {

		v_pos = new Vector3(0, 2f ,0);
		// mybox.init(myPrefab, v_pos, f_size);

		l_sponge = new List<GameObject>();


		GameObject firstBox;
		firstBox = Instantiate(myPrefab, v_pos, Quaternion.identity);
		firstBox.transform.localScale = new Vector3(f_value, f_value, f_value);
		f_value/=3;
		l_sponge.Add(firstBox);	

		// mybox.generate(l_sponge);	
		print("l_sponge.Count: " + l_sponge.Count);
		
	}
	
	void Update () {
	
		if (Input.GetKeyDown("space")){
			
			i_test = l_sponge.Count;
			int deleteBox = l_sponge.Count;

			for(int i=0; i<i_test; i++){
	
				l_sponge[i].GetComponent<boxScript>().init(myPrefab, l_sponge[i].transform.position, f_value );			//Mathf.Pow(3, i+1)
				l_sponge[i].GetComponent<boxScript>().generate(l_sponge);

			}

			print("l_sponge.Count: " +l_sponge.Count + " i_test: " + i_test + " deleteBox: " + deleteBox);
			f_value/=3;



			for(int i=0; i<deleteBox; i++){
				Destroy(l_sponge[i]);
			}
			l_sponge.RemoveRange(0,deleteBox);
			
		}
		
	}
}
