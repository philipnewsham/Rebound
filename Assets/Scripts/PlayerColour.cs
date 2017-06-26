using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerColour : MonoBehaviour
{

    private float[] m_playerOneValues = new float[3];

    public float[] playerOneBaseValues;
    public Slider[] playerOneSliders;

    public Image playerOneImage;

    private float[] m_playerTwoValues = new float[3];

    public float[] playerTwoBaseValues;
    public Slider[] playerTwoSliders;

    public Image playerTwoImage;

    private LevelOptions m_levelOptions;
    void Start()
    {
        m_levelOptions = GameObject.FindGameObjectWithTag("Options").GetComponent<LevelOptions>();
        LoadColour();
    }

    public void ChangePlayerOneColours()
    {
        for (int i = 0; i < 3; i++)
        {
            m_playerOneValues[i] = playerOneSliders[i].value;
        }
        PlayerOneUpdateColour();
    }

    void PlayerOneUpdateColour()
    {
        playerOneImage.color = new Color(m_playerOneValues[0], m_playerOneValues[1], m_playerOneValues[2], 1);
    }

    public void PlayerOneRevertToBase()
    {
        for (int i = 0; i < 3; i++)
        {
            m_playerOneValues[i] = playerOneBaseValues[i];
            playerOneSliders[i].value = m_playerOneValues[i];
        }

        SaveColour();
    }

    public void ChangePlayerTwoColours()
    {
        for (int i = 0; i < 3; i++)
        {
            m_playerTwoValues[i] = playerTwoSliders[i].value;
        }
        PlayerTwoUpdateColour();
    }

    void PlayerTwoUpdateColour()
    {
        playerTwoImage.color = new Color(m_playerTwoValues[0], m_playerTwoValues[1], m_playerTwoValues[2], 1);
    }

    public void PlayerTwoRevertToBase()
    {
        for (int i = 0; i < 3; i++)
        {
            m_playerTwoValues[i] = playerTwoBaseValues[i];
            playerTwoSliders[i].value = m_playerTwoValues[i];
        }

        SaveColour();
    }

    public void SaveColour()
    {
        PlayerPrefs.SetFloat("PlayerOneRedValue", m_playerOneValues[0]);
        PlayerPrefs.SetFloat("PlayerOneGreenValue", m_playerOneValues[1]);
        PlayerPrefs.SetFloat("PlayerOneBlueValue", m_playerOneValues[2]);

        PlayerPrefs.SetFloat("PlayerTwoRedValue", m_playerTwoValues[0]);
        PlayerPrefs.SetFloat("PlayerTwoGreenValue", m_playerTwoValues[1]);
        PlayerPrefs.SetFloat("PlayerTwoBlueValue", m_playerTwoValues[2]);

        SendToOptions();
    }

    void LoadColour()
    {
        if (PlayerPrefs.HasKey("PlayerOneRedValue"))
        {
            m_playerOneValues[0] = PlayerPrefs.GetFloat("PlayerOneRedValue");
            playerOneSliders[0].value = m_playerOneValues[0];

            m_playerOneValues[1] = PlayerPrefs.GetFloat("PlayerOneGreenValue");
            playerOneSliders[1].value = m_playerOneValues[1];

            m_playerOneValues[2] = PlayerPrefs.GetFloat("PlayerOneBlueValue");
            playerOneSliders[2].value = m_playerOneValues[2];
        }
        else
        {
            PlayerOneRevertToBase();
        }

        if (PlayerPrefs.HasKey("PlayerTwoRedValue"))
        {
            m_playerTwoValues[0] = PlayerPrefs.GetFloat("PlayerTwoRedValue");
            playerTwoSliders[0].value = m_playerTwoValues[0];

            m_playerTwoValues[1] = PlayerPrefs.GetFloat("PlayerTwoGreenValue");
            playerTwoSliders[1].value = m_playerTwoValues[1];

            m_playerTwoValues[2] = PlayerPrefs.GetFloat("PlayerTwoBlueValue");
            playerTwoSliders[2].value = m_playerTwoValues[2];
        }
        else
        {
            PlayerTwoRevertToBase();
        }
        SendToOptions();
    }

    void SendToOptions()
    {
        m_levelOptions.playerOneColour = new Vector3(m_playerOneValues[0], m_playerOneValues[1], m_playerOneValues[2]);
        m_levelOptions.playerTwoColour = new Vector3(m_playerTwoValues[0], m_playerTwoValues[1], m_playerTwoValues[2]);
    }
    /*
private float m_redVal1;
private float m_greenVal1;
private float m_blueVal1;
*/
    /*
public float baseRedVal1;
public float baseGreenVal1;
public float baseBlueVal1;
*/
    /*
public void ChangeRed1()
{
    m_redVal1 = colourSliders1[0].value;
    UpdateColour1();
}

public void ChangeGreen1()
{
    m_greenVal1 = colourSliders1[1].value;
    UpdateColour1();
}

public void ChangeBlue1()
{
    m_blueVal1 = colourSliders1[2].value;
    UpdateColour1();
}
*/
}
