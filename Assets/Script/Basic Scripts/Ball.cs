using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public GameObject ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "BlueGoal"){
			transform.position = new Vector3 (0f,0f,0f);
			GetComponent<Rigidbody2D>().AddForce(Vector3.left * 500);
		}
		if (target.gameObject.tag == "RedGoal") {
			transform.position = new Vector3 (0f,0f,0f);
			GetComponent<Rigidbody2D>().AddForce(Vector3.right * 500);
				}
		if (target.gameObject.tag == "Respawn") {
			Instantiate(ball,new Vector3 (0f,0f,0f), Quaternion.identity);
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player")
						Destroy (gameObject);
	}
}
