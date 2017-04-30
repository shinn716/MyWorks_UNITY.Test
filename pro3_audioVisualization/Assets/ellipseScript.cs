using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ellipseScript : MonoBehaviour {

	
    public float radius = 1f;
    private LineRenderer LineDrawer;
	float angle;
	int num=120;
	public float px=-8.9f,py;
	public Material mat;

    void Start ()
    {       
        LineDrawer = GetComponent<LineRenderer>();
		// LineDrawer.material = new Material(Shader.Find("Sprites/Default"));
		LineDrawer.material = mat;
		// Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
    	// LineDrawer.material = whiteDiffuseMat;
		print("addChild");
		// draw();
    }

    void Update ()
    {    
		draw();
		
    }


	 void draw(){
		angle = (float) 360/num;
		LineDrawer.SetVertexCount(num+1);
		for(int i=0; i<num+1; i++){
            if(i==num){
                float x = px + radius* Mathf.Cos(Mathf.Deg2Rad *0);
    			float y = py + radius* Mathf.Sin(Mathf.Deg2Rad *0);                
                LineDrawer.SetPosition(i, new Vector3(x, y, 0));
            }else{
              	float x = px + radius* Mathf.Cos(Mathf.Deg2Rad *i*angle);
    			float y = py + radius* Mathf.Sin(Mathf.Deg2Rad *i*angle);
                LineDrawer.SetPosition(i, new Vector3(x, y, 0));
            }
			// LineDrawer.material = mat;
		}
	}

	public void fixPos(float tarPx, float tarPy, float tarRadius){
		px = tarPx;
		py = tarPy;
		radius = tarRadius;
	}
}
