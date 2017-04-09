using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRotate : MonoBehaviour {
    public bool goalRotate;
    public bool isClockwise;
    private float m_speed = 25f;
	// Use this for initialization
	void Start ()
    {
		if(!isClockwise)
        {
            m_speed = m_speed * -1f;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(goalRotate)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + Time.deltaTime * m_speed);
        }
	}
}
