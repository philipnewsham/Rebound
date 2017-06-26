using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    private GameObject[] players;
    private Camera m_camera;
	// Use this for initialization
	void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        m_camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float width = Mathf.Abs(players[0].transform.position.x - players[1].transform.position.x);
        float halfWidth = width / 2;
        float clampedWidth = Mathf.Clamp(width, 1, 6);
        m_camera.orthographicSize = clampedWidth;
        float height = -1.5f + (clampedWidth * 0.42f);
        if (players[0].transform.position.x < players[1].transform.position.x)
        {
            transform.position = new Vector3(players[0].transform.position.x + halfWidth,height,-10);
        }
        else
        {
            transform.position = new Vector3(players[1].transform.position.x + halfWidth,height,-10);
        }
      
        print(width);	
	}
}
