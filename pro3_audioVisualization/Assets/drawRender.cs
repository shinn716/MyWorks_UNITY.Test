using UnityEngine;
using System.Collections;

public class drawRender : MonoBehaviour
{
    public float radius = 3f;
    private LineRenderer LineDrawer;
	float angle;
	int num=120;
	public float step=1f;
	bool once=false;
	float totalDistance=17.8f;
	public GameObject myPrefab;
	GameObject[] ellipse;
	float[] ellipsePos;
	public AudioClip myClip;
	AudioSource myAudio;
	static int ellipseNum=20;
	float[] target;
	bool b_endState=false;
	bool b_endOnce=false;

    void Start ()
    {       
        LineDrawer = GetComponent<LineRenderer>();
		LineDrawer.material = new Material(Shader.Find("Sprites/Default"));

		//----Part of audio visualization
		myAudio = GetComponent<AudioSource>();
		myAudio.clip =  myClip;
		myAudio.Play();
		
		target = new float[ellipseNum];
		ellipsePos = new float[ellipseNum];
    }

    void Update ()
    {    

		if(b_endState){
			print("end radius: " + radius);
			
			for(int i=0; i<ellipseNum; i++){
				ellipse[i].GetComponent<ellipseScript>().fixPos(0, -5f, 0);
    	    }
			
			if(radius<0){
				step=0;
			} else{
				drawStart();
			}
			
		}else{
			if(radius>30){
				print(">30");
				updateEllipse();
			} else{
    	    	drawStart();
			}
			if(radius==30 && once==false){
				print("START");				//-9.5 ~ +9.5
				addEllipse(ellipseNum);
				once=true;
			} 
		}

		if (!myAudio.isPlaying && b_endOnce==false)
        {
			// print("END");
			b_endOnce=true;
			step=-step;
			b_endState=true;	
			myAudio.Stop();
			print("END-step " +  step);
        }

		//----Test
		if(Input.GetKeyDown(KeyCode.Space)){
			radius=3f;
		}
		
    }

	void updateEllipse(){
		float[] spectrum = AudioListener.GetSpectrumData(1024,0,FFTWindow.Hamming);
		print("Length " + ellipse.Length + " spectrum " + spectrum.Length);	
		for(int i=0; i<ellipseNum; i++){
			spectrum[i]*=10f;
			target[i] += (spectrum[i]-target[i])*0.6f;
			ellipse[i].GetComponent<ellipseScript>().fixPos(ellipsePos[i], 0, target[i]);
        }
	}

	void addEllipse(int tmp){

		for(int i=0; i<tmp; i++){
			// print(i);
			float prec = i / (float)tmp;
			float x = -8.9f + totalDistance/(tmp*2) + prec*totalDistance;
            float y = 0f;
			ellipsePos[i]=x;

			GameObject newEllipse; 
			newEllipse = (GameObject)Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			newEllipse.GetComponent<ellipseScript>().fixPos(ellipsePos[i], 0, 1);
		}	
		ellipse = GameObject.FindGameObjectsWithTag("ellipses");
		// print("Length " + ellipse.Length);
	}

	 void drawStart(){
		angle = (float) 360/num;
		LineDrawer.SetVertexCount(num+1);
		for(int i=0; i<num+1; i++){
            if(i==num){
                float x = radius* Mathf.Cos(Mathf.Deg2Rad *0);
    			float y = radius* Mathf.Sin(Mathf.Deg2Rad *0);                
                LineDrawer.SetPosition(i, new Vector3(x, y, 20));
            }else{
              	float x = radius* Mathf.Cos(Mathf.Deg2Rad *i*angle);
    			float y = radius* Mathf.Sin(Mathf.Deg2Rad *i*angle);
                LineDrawer.SetPosition(i, new Vector3(x, y, 20));
            }
		}

		if(Time.frameCount%2==0){
			radius+=step;
		}
	}

	
}