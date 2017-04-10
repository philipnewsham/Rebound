using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RedGoal : MonoBehaviour
{
	public int redScore;
    public Text score;
    private GameFinish m_gameFinish;
    private int m_goalAmount;
	// Use this for initialization
	void Start () {
		redScore = 0;
        m_gameFinish = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameFinish>();

        if (GameObject.FindGameObjectWithTag("Options"))
        {
            m_goalAmount = GameObject.FindGameObjectWithTag("Options").GetComponent<LevelOptions>().goalAmount;
        }
        else
        {
            m_goalAmount = 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Ball")
						redScore += 1;

        score.text = string.Format("0{0}", redScore);

        if (redScore >= m_goalAmount)
            m_gameFinish.GameOver(true);
    }
}
