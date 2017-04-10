using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int m_goalAmount = 5;
    public Button[] changeGoalAmountButtons;
    public Text goalAmountText;
    public GameObject options;
    private GameObject m_optionsClone;

    void Start()
    {
        if(!GameObject.FindGameObjectWithTag("Options"))
        {
            m_optionsClone = Instantiate(options, transform.position, Quaternion.identity) as GameObject;
            m_optionsClone.GetComponent<LevelOptions>().goalAmount = m_goalAmount;
        }
        else
        {
            m_optionsClone = GameObject.FindGameObjectWithTag("Options");
        }

        LoadOptions();
    }

    public void ChooseScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void RandomLevel()
    {
        int level = Random.Range(3, 6);
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void AddGoalAmount()
    {
        m_goalAmount += 1;
        if (m_goalAmount == 9)
        {
            changeGoalAmountButtons[1].interactable = false;
        }

        if (!changeGoalAmountButtons[0].interactable)
        {
            changeGoalAmountButtons[0].interactable = true;
        }
        ChangeGoalAmountText();
    }

    public void SubGoalAmount()
    {
        m_goalAmount -= 1;
        if (m_goalAmount == 1)
        {
            changeGoalAmountButtons[0].interactable = false;
        }

        if (!changeGoalAmountButtons[1].interactable)
        {
            changeGoalAmountButtons[1].interactable = true;
        }
        ChangeGoalAmountText();
    }

    void LoadOptions()
    {
        if (PlayerPrefs.HasKey("Goals"))
        {
            m_goalAmount = PlayerPrefs.GetInt("Goals");
            ChangeGoalAmountText();
            switch(m_goalAmount)
            {
                case 1:
                    changeGoalAmountButtons[0].interactable = false;
                    break;
                case 9:
                    changeGoalAmountButtons[1].interactable = false;
                    break;
            }
        }
        else
        {
            m_goalAmount = 5;
            SaveOptions();
        }
    }

    void SaveOptions()
    {
        PlayerPrefs.SetInt("Goals", m_goalAmount);

        m_optionsClone.GetComponent<LevelOptions>().goalAmount = m_goalAmount;
    }

    void ChangeGoalAmountText()
    {
        goalAmountText.text = string.Format("First to {0} goals", m_goalAmount);
        SaveOptions();

    }
}