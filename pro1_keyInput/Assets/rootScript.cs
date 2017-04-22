using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rootScript : MonoBehaviour {

	// Use this for initialization

	public GameObject myPrefab;
	public GameObject myCubes;
	public GameObject myPlane;
	float spain=0;
	float spainStep=0.5f;
	int totalCubes=5;
	Mesh mesh;
	List<Vector3> verts = new List<Vector3>();

	public static int score=0;
	float f_time=0f;
	float f_timeGenerate=5f;
	bool b_gameOver=false;
	float f_timeOut=60;
	public Text t_score;
	public Text t_time;
	public Text t_result;

	void Start () {
		mesh = myPlane.GetComponent<MeshFilter>().mesh;
		addSomeCubes(totalCubes);
		updateVertices();
	}

	void updateVertices(){
		verts.Clear();
		for(int i=0; i<mesh.vertexCount; i++){
			Vector3 newPos = mesh.vertices[i];
            int col=i%10;
            // newPos.y = 0.2f * Mathf.Sin(col*Time.frameCount*.01f);
			newPos.y = 0.2f * Random.Range(0.5f,2f);
			verts.Add(newPos);
		}
        mesh.SetVertices(verts);
        mesh.RecalculateNormals();		
	}
	
	void addSomeCubes(int total){
		for(int i=0; i<total; i++){
			float cubeSize = Random.Range(0.8f, 1.5f);
			GameObject newCubes;
 			newCubes = Instantiate(myCubes, new Vector3(Random.Range(-5f,5f), Random.Range(5f,10f), Random.Range(-5f,5f)), Quaternion.identity);
			newCubes.transform.localScale=new Vector3(cubeSize,cubeSize,cubeSize);
		}
	}

	// Update is called once per frame
	void showString(){
		t_score.text = "SCORE: "+score;
		t_time.text = "TIMEOUT: "+Mathf.Round(f_timeOut);
	}
	void Update () {

		showString();

		// f_time+=Time.deltaTime;
		// print("time: "+ f_time);
		// if(f_time>f_timeGenerate && b_gameOver==false){
		// 	f_time=0;
		// 	float cubeSize = Random.Range(0.8f, 1.5f);
		// 	GameObject newCubes;
 		// 	newCubes = Instantiate(myCubes, new Vector3(Random.Range(-5f,5f), Random.Range(5f,10f), Random.Range(-5f,5f)), Quaternion.identity);
		// 	newCubes.transform.localScale=new Vector3(cubeSize,cubeSize,cubeSize);
		// }

		if(f_timeOut<=0){
			f_timeOut=0;
			b_gameOver=true;
			t_result.text="TIME OUT.\nYOUR SCORE: "+score;
		}else{
			f_timeOut-=0.1f;
		}


		if (Input.GetKey("r")&&b_gameOver==false){
			myPrefab.transform.position=new Vector3(0,10f,0);
		}

		if (Input.GetKey("up")&&b_gameOver==false){
			// print("up arrow key is held down");
			myPrefab.transform.Rotate(new Vector3(0,0,spainStep));
			myPrefab.transform.position += new Vector3(-0.1f,0,0);
		}
        
        
        if (Input.GetKey("down")&&b_gameOver==false){
			// print("down arrow key is held down");
			myPrefab.transform.Rotate(new Vector3(0,0,-spainStep));
			myPrefab.transform.position += new Vector3(0.1f,0,0);
		}
            

        if (Input.GetKey("left")&&b_gameOver==false){
			// print("down arrow key is held left");
			myPrefab.transform.Rotate(new Vector3(-spainStep,0,0));
			myPrefab.transform.position += new Vector3(0,0,-0.1f);
		}
            

		if (Input.GetKey("right")&&b_gameOver==false){
			// print("down arrow key is held right");
			myPrefab.transform.Rotate(new Vector3(spainStep,0,0));
			myPrefab.transform.position += new Vector3(0,0,0.1f);
		}
            
	}
}
