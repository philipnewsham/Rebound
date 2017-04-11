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
    private LevelOptions m_levelOptions;
    void Start()
    {
        if(!GameObject.FindGameObjectWithTag("Options"))
        {
            m_optionsClone = Instantiate(options, transform.position, Quaternion.identity) as GameObject;
            m_levelOptions = m_optionsClone.GetComponent<LevelOptions>();
            //m_levelOptions.goalAmount = m_goalAmount;
        }
        else
        {
            m_optionsClone = GameObject.FindGameObjectWithTag("Options");
            m_levelOptions = m_optionsClone.GetComponent<LevelOptions>();
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
    private bool m_goalRotate;
    private int m_goalRotInt;
    public void EnableGoalRotate()
    {
        if(m_affectRotateToggle)
        m_goalRotate = !m_goalRotate;
        if (m_goalRotate)
            m_goalRotInt = 1;
        else
            m_goalRotInt = 0;
        SaveOptions();
    }
    public Toggle goalRotateToggle;
    bool m_affectRotateToggle = true;
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
        
        if(PlayerPrefs.HasKey("GoalRotate"))
        {
            m_goalRotInt = PlayerPrefs.GetInt("GoalRotate");
            m_affectRotateToggle = false;
            if (m_goalRotInt == 0)
                goalRotateToggle.isOn = false;
            else
                goalRotateToggle.isOn = true;
            m_affectRotateToggle = true;
        }
        else
        {

        }
    }

    void SaveOptions()
    {
        PlayerPrefs.SetInt("Goals", m_goalAmount);
        PlayerPrefs.SetInt("GoalRotate", m_goalRotInt);
        m_levelOptions.goalAmount = m_goalAmount;

        if (m_goalRotInt == 0)
            m_goalRotate = false;
        else
            m_goalRotate = true;

        m_levelOptions.goalRotate = m_goalRotate;
    }

    void ChangeGoalAmountText()
    {
        goalAmountText.text = string.Format("First to {0} goals", m_goalAmount);
        SaveOptions();

    }
}