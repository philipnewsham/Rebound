using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour
{
    public void LoadScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }
    /*
	public int level;
	
	private float posX;
	private float posY;
	
	public bool level1;
	public bool level2;
	public bool level3;
	
	// Use this for initialization
	void Start () {
		level = 5;
		posX = transform.position.x;
		posY = transform.position.y;
		
		level1 = true;
		level2 = false;
		level3 = false;

	}
	
	// Update is called once per frame
	void Update () {
		//scrolling
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			
			posX = transform.position.x;
			posY = transform.position.y + 2f;
			transform.position = new Vector2 (posX, posY);
			if (posY > 1.5f)
				transform.position = new Vector2 (posX, -2.6f);
		}
		
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			posX = transform.position.x;
			posY = transform.position.y - 2f;
			transform.position = new Vector2 (posX, posY);
			if (posY < -2.6f)
				transform.position = new Vector2 (posX, 1.4f);
		}
		
		//selecting
		if ((level1 == true) && (Input.GetKeyDown (KeyCode.Space))) 
			Application.LoadLevel (5);
		if ((level2 == true) && (Input.GetKeyDown (KeyCode.Space))) 
			Application.LoadLevel (6);
		if ((level3 == true) && (Input.GetKeyDown (KeyCode.Space))) 
			Application.LoadLevel (7);
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "level1")
			level1 = true;
		if (target.gameObject.tag == "level2") 
			level2 = true;
		if (target.gameObject.tag == "level3") 
			level3 = true;
	}
	
	void OnTriggerExit2D(Collider2D target){
		if (target.gameObject.tag == "level1") 
			level1 = false;
		if (target.gameObject.tag == "level2") 
			level2 = false;
		if (target.gameObject.tag == "level3") 
			level3 = false;
	}
    */

}