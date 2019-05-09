using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_loader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void loadStartScene()
    {
        
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void loadLevel1()
    {

        SceneManager.LoadScene(1);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void loadLevel2()
    {

        SceneManager.LoadScene(2);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void loadLevel3()
    {

        SceneManager.LoadScene(3);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void loadLevel4()
    {

        SceneManager.LoadScene(4);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void loadLevel5()
    {

        SceneManager.LoadScene(5);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
}
