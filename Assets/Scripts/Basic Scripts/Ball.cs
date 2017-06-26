using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public GameObject ball;
    private Vector2 m_startPosition;
    private GameFinish m_gameFinish;
	// Use this for initialization
	void Start ()
    {
        //m_startPosition = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameFinish>().startPosition;
        m_startPosition = transform.position;
    }

	void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "RedGoal" || target.gameObject.tag == "BlueGoal" || target.gameObject.tag == "Respawn")
        {
            Respawn();
        }
	}

    public void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = m_startPosition;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
	
	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") { }
						//Destroy (gameObject);
	}
}
