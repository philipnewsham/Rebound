using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameFinish : MonoBehaviour
{
    string m_winnerString;
    public GameObject endPanel;
    public Text winningText;
    public RedGoal redGoal;
    public BlueGoal blueGoal;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            RespawnBall();
        }
    }

    void RespawnBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.transform.position = new Vector2(0, 0);
    }

    public void GameOver(bool isRed)
    {
        endPanel.SetActive(true);

        if(isRed)
        {
            //m_winnerString = "<color=#ff0000ff>Red</color=\ff0000ff>";
            m_winnerString = "Player Two";
        }
        else
        {
            //m_winnerString = "<color=#ff0000ff>Blue</color=\00ffffff>";
            m_winnerString = "Player One";
        }
        winningText.text = string.Format("{0} wins {1} - {2}!", m_winnerString, redGoal.redScore, blueGoal.blueScore);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
