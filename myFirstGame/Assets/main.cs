using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	private float time=0;
	public GameObject mine;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime; //時間增加
		if(time>2f) //如果時間大於0.5(秒)
		{
			Vector3 pos = new Vector3(Random.Range(-12f,12f),Random.Range(-12f,12f),0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
			Instantiate(mine,pos,transform.rotation); //產生敵人
			time = 0f; //時間歸零
		}
	}
}
