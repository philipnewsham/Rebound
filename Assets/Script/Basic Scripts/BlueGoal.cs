using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlueGoal : MonoBehaviour
{
	public int blueScore;
    public Text score;
    private Image m_scoreImage;
    private GameFinish m_gameFinish;
    private int m_goalAmount;

    private LevelOptions m_levelOptions;

    public bool m_goalRotate;
    public bool isClockwise;
    private float m_speed = 25f;

    public Transform[] parent;
    public Vector3 baseColour;
    private SpriteRenderer m_spriteRenderer;
    void Start()
    {
        blueScore = 0;
        m_gameFinish = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameFinish>();
        parent = GetComponentsInParent<Transform>();
        m_scoreImage = score.GetComponentInParent<Image>();
        if(GameObject.FindGameObjectWithTag("Options"))
        {
            m_levelOptions = GameObject.FindGameObjectWithTag("Options").GetComponent<LevelOptions>();
            m_goalAmount = m_levelOptions.goalAmount;
            m_goalRotate = m_levelOptions.goalRotate;
        }
        else
        {
            m_goalAmount = 3;
        }
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        GrabColour();
    }

    void GrabColour()
    {
        if (GameObject.FindGameObjectWithTag("Options"))
        {
            LevelOptions levelOptions = GameObject.FindGameObjectWithTag("Options").GetComponent<LevelOptions>();
            m_spriteRenderer.color = new Color(levelOptions.playerOneColour.x, levelOptions.playerOneColour.y, levelOptions.playerOneColour.z, .75f);
            m_scoreImage.color = new Color(levelOptions.playerOneColour.x, levelOptions.playerOneColour.y, levelOptions.playerOneColour.z, 1f);
        }
        else
        {
            m_spriteRenderer.color = new Color(baseColour.x, baseColour.y, baseColour.z, .75f);
            m_scoreImage.color = new Color(baseColour.x, baseColour.y, baseColour.z, 1f);

        }
    }

    void Update()
    {
        if (m_goalRotate)
        {
            parent[1].transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + Time.deltaTime * m_speed);
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