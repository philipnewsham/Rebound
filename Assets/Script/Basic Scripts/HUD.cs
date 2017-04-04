using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GameObject pause;
	public bool paused = false;

	public GUIStyle myScript;

	public GameObject bluescore;
	public BlueGoal bluegoalScript;
	public int blueCount;

	public GameObject redscore;
	public RedGoal redgoalScript;
	public int redCount;

	public Texture2D redgraphic;
	public Texture2D bluegraphic;

	// Use this for initialization
	void Start () {
		redscore = GameObject.FindGameObjectWithTag ("RedGoal");
		redgoalScript = redscore.GetComponent<RedGoal> ();

		bluescore = GameObject.FindGameObjectWithTag ("BlueGoal");
		bluegoalScript = bluescore.GetComponent<BlueGoal> ();
	}
	
	// Update is called once per frame
	void Update () {
		//pause
		if (Input.GetKeyDown (KeyCode.Escape)){
			if(Time.timeScale == 1.0f){
				Instantiate(pause,new Vector3 (transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
				Time.timeScale = 0.0f;
			}else{
				Time.timeScale = 1.0f;
			}
		}

		redCount = redgoalScript.redScore;
		blueCount = bluegoalScript.blueScore;
	}
	void OnGUI() {

		string RedScore = redCount.ToString ();
		if (RedScore.Length == 1) {
			RedScore = "0" + RedScore;
		}
		string BlueScore = blueCount.ToString ();
		if (BlueScore.Length == 1) {
			BlueScore = "0" + BlueScore;
		}

		GUI.BeginGroup (new Rect (100, 50, 100, 100));
		GUI.DrawTexture (new Rect (0, 0, 200, 100), redgraphic);
		GUI.EndGroup ();

		GUI.BeginGroup (new Rect (800, 50, 100, 100));
		GUI.DrawTexture (new Rect (0, 0, 200, 100), bluegraphic);
		GUI.EndGroup ();

		GUI.Label (new Rect (115, 50, 100, 50),RedScore, myScript);
		GUI.Label (new Rect (815, 50, 100, 50),BlueScore, myScript);
		}
}