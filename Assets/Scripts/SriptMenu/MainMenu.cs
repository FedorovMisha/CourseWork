using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    
    public void PlayScene()
    {
        SceneManager.LoadScene(0);
    }
}
