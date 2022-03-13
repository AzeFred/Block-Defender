using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
     }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        if (FindObjectOfType<GameStatus>() != null)
        {
            FindObjectOfType<GameStatus>().ResetGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
