using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    // Creates a line renderer that follows a Sin() function
    // and animates it.

    public LineRenderer lr;


    public float radius = 5f;
	float angle;
	int size=120;
    float px, py;
    Vector3[] positions;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        angle = (float) 360/size;


        draw();
    }

    void Update()
    {

    }

    void draw(){
		angle = (float) 360/size;
		lr.SetVertexCount(size+1);
		for(int i=0; i<size+1; i++){
            if(i==size){
                float x = px + radius* Mathf.Cos(Mathf.Deg2Rad *0);
    			float y = py + radius* Mathf.Sin(Mathf.Deg2Rad *0);                
                lr.SetPosition(i, new Vector3(x, y, 0));
            }else{
              	float x = px + radius* Mathf.Cos(Mathf.Deg2Rad *i*angle);
    			float y = py + radius* Mathf.Sin(Mathf.Deg2Rad *i*angle);
                lr.SetPosition(i, new Vector3(x, y, 0));
            }
			lr.material = new Material(Shader.Find("Particles/Additive"));
		}
	}
}