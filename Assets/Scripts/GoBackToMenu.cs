using UnityEngine;
using System.Collections;

public class GoBackToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.Backspace))
						Application.LoadLevel (1);
	}
}
