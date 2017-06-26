using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOptions : MonoBehaviour
{
    public int goalAmount;
    public bool goalRotate;
    public Vector3 playerOneColour;
    public Vector3 playerTwoColour;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}
}
