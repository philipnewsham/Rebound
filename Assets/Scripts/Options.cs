using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
    private int m_goalAmount;
    public Button[] changeGoalAmountButtons;
    public Text goalAmountText;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}
    
    public void AddGoalAmount()
    {
        if (m_goalAmount == 9)
        {
            changeGoalAmountButtons[1].interactable = false;
        }

        if (!changeGoalAmountButtons[0].interactable)
        {
            changeGoalAmountButtons[0].interactable = true;
        }
    }

    public void SubGoalAmount()
    {
        m_goalAmount -= 1;
        if(m_goalAmount == 1)
        {
            changeGoalAmountButtons[0].interactable = false;
        }

        if(!changeGoalAmountButtons[1].interactable)
        {
            changeGoalAmountButtons[1].interactable = true;
        }
        ChangeGoalAmountText();
    }

    void ChangeGoalAmountText()
    {
        goalAmountText.text = string.Format("First to {0} goals", m_goalAmount);
    }
}
