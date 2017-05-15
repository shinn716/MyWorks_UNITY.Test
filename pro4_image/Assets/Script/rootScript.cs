using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootScript : MonoBehaviour {

	public Texture2D t_readImage;
	int i_width=512, i_height=512;
	int i_size = 4;
	float f_scale=50000f;
	Color[] c_pixels;
	public GameObject myPrefab;
	GameObject[,] g_cubes;
	float[,] f_z;
	float f_speed = 0.01f;

	
	void Start () {

		int num = i_width/i_size;

        int imgX = Mathf.FloorToInt(0);
        int imgY = Mathf.FloorToInt(0);
        int imgWidth = Mathf.FloorToInt(t_readImage.width);
        int imgHeight = Mathf.FloorToInt(t_readImage.height);
		c_pixels = t_readImage.GetPixels(imgX, imgY, imgWidth, imgHeight);


		g_cubes = new GameObject[num, num];
		f_z = new float[num, num];

		for(int j=0; j<num; j++){
			for(int i=0; i<num; i++){

				// GameObject newCubes  = GameObject.CreatePrimitive(PrimitiveType.Cube);
				int x = i_size*i+i_size/2;
				int y = i_size*j+i_size/2;
				int loc = x + y * i_width;
				

				g_cubes[i, j] = (GameObject)Instantiate(myPrefab, new Vector3(x -i_width/2, y -i_height/2, 0), Quaternion.identity);			//color.grayscale*f_scale
                g_cubes[i, j].transform.localScale = new Vector3(i_size-0.1f, i_size-0.1f, i_size-0.1f);
				
				Color color = c_pixels[loc];
				g_cubes[i, j].GetComponent<Renderer>().material.color = color;

				// Color color = c_pixels[loc];
				// newCubes.transform.localScale = new Vector3(i_size-0.1f, i_size-0.1f, i_size-0.1f);
				// newCubes.transform.position = new Vector3(x -i_width/2, y -i_height/2, color.grayscale*f_scale);
				// newCubes.GetComponent<Renderer>().material.color = color;
				
			}
		}
		// g_cubes = GameObject.FindGameObjectsWithTag("myCubes");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("space")){
			print("SPACE");
			int num = i_width/i_size;
			
			for(int j=0; j<num; j++){
				for(int i=0; i<num; i++){

					int x = i_size*i+i_size/2;
					int y = i_size*j+i_size/2;
					int loc = x + y * i_width;

					Color color = c_pixels[loc];	
					// f_z[i, j] = Mathf.Lerp(f_z[i, j], color.grayscale, f_speed);
					f_z[i, j] = Mathf.Lerp(f_z[i, j], 0, f_speed);
					g_cubes[i, j].transform.position = new Vector3(x -i_width/2, y -i_height/2, f_z[i, j]*f_scale);
	
				}

			}
		}else{

			int num = i_width/i_size;

			for(int j=0; j<num; j++){
				for(int i=0; i<num; i++){

					int x = i_size*i+i_size/2;
					int y = i_size*j+i_size/2;
					int loc = x + y * i_width;

					Color color = c_pixels[loc];
					f_z[i, j] = Mathf.Lerp(f_z[i, j], color.grayscale, f_speed);
					// f_z[i, j] = Mathf.Lerp(f_z[i, j], 0, f_speed);
					g_cubes[i, j].transform.position = new Vector3(x -i_width/2, y -i_height/2, f_z[i, j]*f_scale);
	
				}

			}


		}

	}

	// Debug.Log(Map(0,10,0,1024,500));
	public float Map(float from, float to, float from2, float to2, float value){
        if(value <= from2){
            return from;
        }else if(value >= to2){
            return to;
        }else{
            return (to - from) * ((value - from2) / (to2 - from2)) + from;
        }
    }
}
