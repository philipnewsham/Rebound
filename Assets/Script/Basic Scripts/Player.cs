using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float posX;
    private float posY;
    public float speed = 0.05f;
    private bool left = false;
    public bool grounded = false;
    public Transform groundedEnd;
    public Sprite[] playerSprites;
    public GameObject ball;
    public bool ballCaught = false;
    public GameObject stealBallLeft;
    public GameObject stealBallRight;
    private bool stolen = false;
    private bool stolenLeft = false;
    //public GameObject Player;
    private bool paused = false;

    public bool isPlayerOne;
    private int m_playerNo;
    private KeyCode[] m_movingLeft = new KeyCode[2] { KeyCode.A, KeyCode.LeftArrow };
    private KeyCode[] m_movingRight = new KeyCode[2] { KeyCode.D, KeyCode.RightArrow };
    private KeyCode[] m_jumping = new KeyCode[2] { KeyCode.W, KeyCode.UpArrow };
    private KeyCode[] m_shooting = new KeyCode[2] { KeyCode.X, KeyCode.N };
    private KeyCode[] m_stealing = new KeyCode[2] { KeyCode.C, KeyCode.M };

    private Vector2 m_startingPosition;

    private SpriteRenderer m_spriteRenderer;
    public Vector3[] baseColours;
    private SpriteRenderer m_ballSprite;
    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (isPlayerOne)
            m_playerNo = 0;
        else
            m_playerNo = 1;

        m_startingPosition = new Vector2(transform.position.x, transform.position.y);

        SpriteRenderer[] childObjects = GetComponentsInChildren<SpriteRenderer>();
        m_ballSprite = childObjects[1];
        m_ballSprite.enabled = false;
        GrabColour();
    }

    void GrabColour()
    {
        if (GameObject.FindGameObjectWithTag("Options"))
        {
            LevelOptions levelOptions = GameObject.FindGameObjectWithTag("Options").GetComponent<LevelOptions>();
            if(isPlayerOne)
                m_spriteRenderer.color = new Color(levelOptions.playerOneColour.x, levelOptions.playerOneColour.y, levelOptions.playerOneColour.z, 1);
            else
                m_spriteRenderer.color = new Color(levelOptions.playerTwoColour.x, levelOptions.playerTwoColour.y, levelOptions.playerTwoColour.z, 1);
        }
        else
        {
            m_spriteRenderer.color = new Color(baseColours[m_playerNo].x, baseColours[m_playerNo].y, baseColours[m_playerNo].z, 1);

        }
    }

    void Update()
    {
        if (ballCaught && stolen)
        {
            Stolen();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (!paused)
        {
            if (Input.GetKey(m_movingRight[m_playerNo]))
            {
                posX = transform.position.x + speed;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
                left = false;
                transform.localScale = new Vector2(1, 1);
            }
            if (Input.GetKey(m_movingLeft[m_playerNo]))
            {
                posX = transform.position.x - speed;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
                left = true;
                transform.localScale = new Vector2(-1, 1);
            }

            if (Input.GetKeyDown(m_jumping[m_playerNo]) && grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            }

            if (Input.GetKeyDown(m_shooting[m_playerNo]) && ballCaught)
            {
                Shoot();
            }

            if (Input.GetKeyDown(m_stealing[m_playerNo]) && !ballCaught)
            {
                Tackle();
            }
        }
        Raycasting();
    }

    void Raycasting()
    {
        Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);

        grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));

        Physics2D.IgnoreLayerCollision(9, 10);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            //playerAnim.SetBool("BlueBall", true);
            //GetComponent<SpriteRenderer>().sprite = playerSprites[1];
            m_ballSprite.enabled = true;
            ballCaught = true;
            speed = 0.03f;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "stealBallLeft")
        {
            stolen = true;
            stolenLeft = true;
        }

        if (target.gameObject.tag == "stealBallRight")
        {
            stolen = true;
        }
        if (target.gameObject.tag == "Respawn")
        {
            transform.position = m_startingPosition;
            if (ballCaught)
            {
                Instantiate(ball, new Vector3(0f, 0f, 0f), Quaternion.identity);
                ballCaught = false;
                speed = 0.05f;
                //GetComponent<SpriteRenderer>().sprite = playerSprites[0];
                m_ballSprite.enabled = false;
            }
            
        }
    }
    float m_posXProj;
    Vector3 m_dirProj;
    void Shoot()
    {
        if (!left)
        {
            m_posXProj = transform.position.x + 0.5f;
            m_dirProj = Vector2.right;
        }
        else
        {
            m_posXProj = transform.position.x - 0.5f;
            m_dirProj = Vector2.left;
        }

        GameObject proj = Instantiate(ball, new Vector3((m_posXProj), transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        proj.GetComponent<Rigidbody2D>().AddForce(m_dirProj * 500);

        //playerAnim.SetBool("BlueBall", false);
        //GetComponent<SpriteRenderer>().sprite = playerSprites[0];
        m_ballSprite.enabled = false;
        ballCaught = false;
        speed = 0.05f;
    }
    bool canSteal = true;
    void Tackle()
    {
        if (canSteal)
        {
            if (!left)
            {
                GameObject proj = Instantiate(stealBallRight, new Vector3((transform.position.x + 0.5f), transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
                proj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 300);
            }
            else
            {
                GameObject proj = Instantiate(stealBallLeft, new Vector3((transform.position.x - 0.5f), transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
                proj.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 300);
            }
            canSteal = false;
            Invoke("CanSteal", 2f);
        }
    }

    void CanSteal()
    {
        canSteal = true;
    }

    void Stolen()
    {
        if (!stolenLeft)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.right * 100);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 100);
            GameObject proj = Instantiate(ball, new Vector3((transform.position.x), (transform.position.y + 1f), transform.position.z), Quaternion.identity) as GameObject;
            proj.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 150);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 100);
            GameObject proj = Instantiate(ball, new Vector3((transform.position.x), (transform.position.y + 1f), transform.position.z), Quaternion.identity) as GameObject;
            proj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 150);
        }

        stolen = false;
        stolenLeft = false;
        //playerAnim.SetBool("BlueBall", false);
        //GetComponent<SpriteRenderer>().sprite = playerSprites[0];
        m_ballSprite.enabled = false;
        ballCaught = false;
        speed = 0.05f;
    }
}
