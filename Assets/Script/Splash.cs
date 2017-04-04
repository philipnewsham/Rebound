using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadMenu", 2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown)
            LoadMenu();
	}

    void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
