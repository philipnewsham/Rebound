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
	void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "RedGoal" || target.gameObject.tag == "BlueGoal" || target.gameObject.tag == "Respawn")
        {
            Respawn();
        }
	}

    void Respawn()
    {
        transform.position = new Vector2(0f, 0f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player")
						Destroy (gameObject);
	}
}
