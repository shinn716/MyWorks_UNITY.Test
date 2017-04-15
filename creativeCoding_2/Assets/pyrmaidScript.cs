using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pyrmaidScript : MonoBehaviour {

	GameObject pyrmaid;
	public Material material;
	List<Vector3> verts = new List<Vector3>();
	List<int> tris = new List<int>();
	List<Vector2> uvs =new List<Vector2>();
	void Start () {
		pyrmaid=new GameObject();
		pyrmaid.AddComponent<MeshFilter>();
		pyrmaid.AddComponent<MeshRenderer>();

		pyrmaid.GetComponent<MeshRenderer>().material = material;
		bulidPyrmaid();
	}
	
	void bulidPyrmaid(){
		//FACE 1
		//*************************************
		verts.Add(new Vector3(0,0,0));
		verts.Add(new Vector3(1,1.5f,1));
		verts.Add(new Vector3(2,0,0));

		tris.Add(0);
		tris.Add(1);
		tris.Add(2);			

		uvs.Add(new Vector2(0,1));
		uvs.Add(new Vector2(0.5f,0));
		uvs.Add(new Vector2(1,1));

		//FACE 2
		//*************************************
		verts.Add(new Vector3(2,0,0));
		verts.Add(new Vector3(1,1.5f,1));
		verts.Add(new Vector3(2,0,2));

		tris.Add(3);
		tris.Add(4);
		tris.Add(5);			

		uvs.Add(new Vector2(0,1));
		uvs.Add(new Vector2(0.5f,0));
		uvs.Add(new Vector2(1,1));

		//FACE 3
		//*************************************
		verts.Add(new Vector3(2,0,2));
		verts.Add(new Vector3(1,1.5f,1));
		verts.Add(new Vector3(0,0,2));

		tris.Add(6);
		tris.Add(7);
		tris.Add(8);			

		uvs.Add(new Vector2(0,1));
		uvs.Add(new Vector2(0.5f,0));
		uvs.Add(new Vector2(1,1));		

		//FACE 4
		//*************************************
		verts.Add(new Vector3(0,0,2));
		verts.Add(new Vector3(1,1.5f,1));
		verts.Add(new Vector3(0,0,0));

		tris.Add(9);
		tris.Add(10);
		tris.Add(11);			

		uvs.Add(new Vector2(0,1));
		uvs.Add(new Vector2(0.5f,0));
		uvs.Add(new Vector2(1,1));	

		for(int i=0; i<verts.Count; i++){
			Vector3 shift = verts[i];
			shift.x -= 1.0f;
			shift.z -= 1.0f;
			verts[i] = shift;
		}

		Mesh tMesh = new Mesh();

		tMesh.SetVertices(verts);
		tMesh.triangles = tris.ToArray();
		tMesh.uv = uvs.ToArray();

		pyrmaid.GetComponent<MeshFilter>().mesh = tMesh;
		pyrmaid.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
		pyrmaid.transform.Translate(0,1.0f,0);
	}

	// Update is called once per frame
	void Update () {
		pyrmaid.transform.Rotate(0.0f, -0.5f, 0.0f);
	}
}
