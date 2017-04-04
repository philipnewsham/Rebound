using UnityEngine;
using System.Collections;

public class RedGoal : MonoBehaviour {
	public int redScore;
	// Use this for initialization
	void Start () {
		redScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Ball")
						redScore += 1;
	}
}
