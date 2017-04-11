using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RedGoal : MonoBehaviour
{
	public int redScore;
    public Text score;
    private GameFinish m_gameFinish;
    private int m_goalAmount;

    private LevelOptions m_levelOptions;

    public bool m_goalRotate;
    public bool isClockwise;
    private float m_speed = 25f;

    private Transform[] parent;
    // Use this for initialization
    void Start () {
		redScore = 0;
        m_gameFinish = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameFinish>();
        parent = GetComponentsInParent<Transform>();
        if (GameObject.FindGameObjectWithTag("Options"))
        {
            m_levelOptions = GameObject.FindGameObjectWithTag("Options").GetComponent<LevelOptions>();
            m_goalAmount = m_levelOptions.goalAmount;
            m_goalRotate = m_levelOptions.goalRotate;
        }
        else
        {
            m_goalAmount = 3;
        }

        if (!isClockwise)
        {
            m_speed = m_speed * -1f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_goalRotate)
        {
            parent[1].transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + Time.deltaTime * m_speed);
        }
    }

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Ball")
						redScore += 1;

        score.text = string.Format("0{0}", redScore);

        if (redScore >= m_goalAmount)
            m_gameFinish.GameOver(true);


    }
}
