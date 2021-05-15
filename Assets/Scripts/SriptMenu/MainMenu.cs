using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex) ;
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
