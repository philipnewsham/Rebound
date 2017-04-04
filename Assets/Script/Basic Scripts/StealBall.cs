using UnityEngine;
using System.Collections;

public class StealBall : MonoBehaviour {
	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
				if (count > 0)
					count += 1;
				if (count > 12)
					Destroy (gameObject);
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player")
						count = 1;
		if ((target.gameObject.tag == "Respawn") || (target.gameObject.tag == "Floor"))
						Destroy (gameObject);
	}
}
