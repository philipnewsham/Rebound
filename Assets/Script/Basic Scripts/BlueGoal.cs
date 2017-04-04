using UnityEngine;
using System.Collections;

public class BlueGoal : MonoBehaviour {
	public int blueScore;
	// Use this for initialization
	void Start () {
		blueScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Ball")
			blueScore += 1;
	}
}