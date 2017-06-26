using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public GameObject pause;
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.Escape)) {
			Instantiate(pause,new Vector3 (0,0,0), Quaternion.identity);
			if(Time.timeScale == 1.0f){
			Time.timeScale = 0.0f;
				}else{
				Time.timeScale = 1.0f;
			}
	}
}
}
