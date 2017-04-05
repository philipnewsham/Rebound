﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlueGoal : MonoBehaviour
{
	public int blueScore;
    public Text score;
    private GameFinish m_gameFinish;
    void Start()
    {
        blueScore = 0;
        m_gameFinish = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameFinish>();
    }
	void OnTriggerEnter2D(Collider2D target)
    {
		if (target.gameObject.tag == "Ball")
			blueScore += 1;

        score.text = string.Format("0{0}", blueScore);

        if(blueScore >= 3)
            m_gameFinish.GameOver(false);
	}
}