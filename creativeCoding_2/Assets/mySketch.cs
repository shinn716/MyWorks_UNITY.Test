using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mySketch : MonoBehaviour {

    public GameObject plane;
    public bool isJitter=false;
    float jitter = 0.01f;
    Mesh mesh;
    List<Vector3> verts = new List<Vector3>();

    void Start () {
        mesh = plane.GetComponent<MeshFilter>().mesh;
        Debug.Log(mesh.vertexCount);
        updateVertices();


    }

    void updateVertices()
    {
        verts.Clear();
        for (int i=0; i<mesh.vertexCount; i++)
        {
            Vector3 newPos = mesh.vertices[i];
            int col=i%10;
            newPos.y = 0.2f * Mathf.Sin(col*Time.frameCount*.01f);
            
            if(isJitter){
                newPos.y += Random.Range(-jitter, jitter);
                newPos.y += (0 - newPos.y) * .01f;                     //ease
            }

            verts.Add(newPos);
        }
        mesh.SetVertices(verts);
        mesh.RecalculateNormals();
        // mesh.RecalculateBounds();
    }
	
	// Update is called once per frame
	void Update () {
        updateVertices();
        //Debug.Log("hello11");
    }
}
