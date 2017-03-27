using UnityEngine;
using System.Collections;

public class UFOController : MonoBehaviour {
	
	// Use this for initialization
	public float speed;
	private Rigidbody2D rigidbody2D = null;
	public score _score;

	void Start () {
		Debug.Log ("Hellow this is UFO.");
		rigidbody2D = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame

	void Update () {
		Vector2 force2D = Vector2.zero;
		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) 		{force2D.y += speed;}
		if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)) 	{force2D.x -= speed;}
		if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) 	{force2D.y -= speed;}
		if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)) 	{force2D.x += speed;}
		rigidbody2D.AddForce (force2D);





	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		//if(other.gameObject.CompareTag("PickUp")){
		other.gameObject.SetActive(false);	
		_score.addScore(100);	
		//}
	}
}
