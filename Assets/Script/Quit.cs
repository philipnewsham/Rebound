﻿using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown (KeyCode.Y))
		   Application.LoadLevel (1);
		if (Input.GetKeyDown (KeyCode.Escape))
						Destroy (gameObject);
	}
}
