using UnityEngine;
using System.Collections;

public class Red : MonoBehaviour {
	private float posX;
	private float posY;
	public float speed;
	private bool left = true;
	public bool grounded = false;
	public Transform groundedEnd;
	public Animator playerAnim;
	public GameObject ball;
	public bool ballCaught = false;
	public GameObject stealBallLeft;
	public GameObject stealBallRight;
	private bool stolen = false;
	private bool stolenLeft = false;
	public GameObject Player;
	private bool paused;
	
	// Use this for initialization
	void Start () {
		speed = 0.05f;
		playerAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((ballCaught == true) && (stolen == true)) {
			Stolen();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}

		if (ballCaught == true) {
			speed = 0.03f;
		}else {
			speed = 0.05f;
		}
		if (left == true)
			transform.localScale = new Vector2 (-1, 1);
		if (left == false)
			transform.localScale = new Vector2 (1, 1);
		if (paused == false) {
						if (Input.GetKey (KeyCode.RightArrow)) {
								posX = transform.position.x + speed;
								posY = transform.position.y;
								transform.position = new Vector2 (posX, posY);
								left = false;
						}
						if (Input.GetKey (KeyCode.LeftArrow)) {
								posX = transform.position.x - speed;
								posY = transform.position.y;
								transform.position = new Vector2 (posX, posY);
								left = true;
						}
						if ((Input.GetKey (KeyCode.UpArrow)) && (grounded == true)) {
								GetComponent<Rigidbody2D>().AddForce (Vector2.up * 150f);
						}
						if ((Input.GetKeyDown (KeyCode.N)) && (ballCaught == true)) {
								Shoot ();
						}
						if ((Input.GetKeyDown (KeyCode.M)) && (ballCaught == false)) {
								Tackle ();
						}
				}
		Raycasting ();
	}
	
	void Raycasting() {
		
		Debug.DrawLine (this.transform.position, groundedEnd.position, Color.green);
		
		grounded = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer ("Ground"));
		
		Physics2D.IgnoreLayerCollision (9, 10);
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Ball") {
			playerAnim.SetBool ("RedBall", true);
			ballCaught = true;
		}
	}
	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "stealBallLeft"){
			stolen = true;
			stolenLeft = true;
		}
		if(target.gameObject.tag == "stealBallRight"){
			stolen = true;
		}
		if (target.gameObject.tag == "Respawn") {
						Instantiate (Player, new Vector3 (1.25f, -1.5f, 0f), Quaternion.identity);
						if (ballCaught == true){
								Instantiate (ball, new Vector3 (0f, 0f, 0f), Quaternion.identity);
						ballCaught = false;
				}
			Destroy (gameObject);
		}
	}
	void Shoot(){
		if(left == false) {
			GameObject proj = Instantiate(ball,new Vector3 ((transform.position.x + 0.5f),transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
			proj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 500);
		} else {
			GameObject proj = Instantiate(ball,new Vector3 ((transform.position.x - 0.5f),transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
			proj.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 500);
		}
		playerAnim.SetBool ("RedBall",false);
		ballCaught = false;
	}
	
	void Tackle(){
		if(left == false) {
			GameObject proj = Instantiate(stealBallRight,new Vector3 ((transform.position.x + 0.5f),transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
			proj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 300);
		} else {
			GameObject proj = Instantiate(stealBallLeft,new Vector3 ((transform.position.x - 0.5f),transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
			proj.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 300);
		}
	}
	void Stolen(){
		if (stolenLeft == false) {
			GetComponent<Rigidbody2D>().AddForce (Vector3.right * 100);
			GetComponent<Rigidbody2D>().AddForce (Vector3.up * 100);
			GameObject proj = Instantiate(ball,new Vector3 ((transform.position.x),(transform.position.y + 1f),transform.position.z), Quaternion.identity) as GameObject;
			proj.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 150);
		} else {
			GetComponent<Rigidbody2D>().AddForce (Vector3.left * 100);
			GetComponent<Rigidbody2D>().AddForce (Vector3.up * 100);
			GameObject proj = Instantiate(ball,new Vector3 ((transform.position.x),(transform.position.y + 1f),transform.position.z), Quaternion.identity) as GameObject;
			proj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 150);
			
		}
		stolen = false;
		stolenLeft = false;
		playerAnim.SetBool ("RedBall",false);
		ballCaught = false;
	}
}
