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
    public Animator playerAnim;
    public GameObject ball;
    public bool ballCaught = false;
    public GameObject stealBallLeft;
    public GameObject stealBallRight;
    private bool stolen = false;
    private bool stolenLeft = false;
    //public GameObject Player;
    private bool paused = false;
    // Use this for initialization
    void Start()
    {
        playerAnim = GetComponent<Animator>();
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
            if (Input.GetKey(KeyCode.D))
            {
                posX = transform.position.x + speed;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
                left = false;
                transform.localScale = new Vector2(1, 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                posX = transform.position.x - speed;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
                left = true;
                transform.localScale = new Vector2(-1, 1);
            }

            if (Input.GetKeyDown(KeyCode.W) && grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150f);
            }

            if (Input.GetKeyDown(KeyCode.X) && ballCaught)
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.C) && !ballCaught)
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
            playerAnim.SetBool("BlueBall", true);
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
            //Instantiate(Player, new Vector3(-1.25f, -1.5f, 0f), Quaternion.identity);
            transform.position = new Vector2(-1.24f, -1.5f);
            if (ballCaught)
            {
                Instantiate(ball, new Vector3(0f, 0f, 0f), Quaternion.identity);
                ballCaught = false;
                speed = 0.05f;
            }
            Destroy(gameObject);
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

        GameObject proj = Instantiate(ball, new Vector3((transform.position.x - 0.5f), transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        proj.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 500);

        playerAnim.SetBool("BlueBall", false);
        ballCaught = false;
    }

    void Tackle()
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
        playerAnim.SetBool("BlueBall", false);
        ballCaught = false;
    }
}
