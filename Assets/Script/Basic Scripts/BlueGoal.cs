using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlueGoal : MonoBehaviour
{
	public int blueScore;
    public Text score;
    private GameFinish m_gameFinish;
    private int m_goalAmount;
    void Start()
    {
        blueScore = 0;
        m_gameFinish = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameFinish>();

        if(GameObject.FindGameObjectWithTag("Options"))
        {
            m_goalAmount = GameObject.FindGameObjectWithTag("Options").GetComponent<LevelOptions>().goalAmount;
        }
        else
        {
            m_goalAmount = 3;
        }
    }
	void OnTriggerEnter2D(Collider2D target)
    {
		if (target.gameObject.tag == "Ball")
			blueScore += 1;

        score.text = string.Format("0{0}", blueScore);

        if(blueScore >= m_goalAmount)
            m_gameFinish.GameOver(false);
	}
}