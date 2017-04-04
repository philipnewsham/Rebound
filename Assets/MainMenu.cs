using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void ChooseScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

    public void RandomLevel()
    {
        int level = Random.Range(5, 8);
        SceneManager.LoadScene(level);
    }
    public void Quit()
    {
        Application.Quit();
    }
}