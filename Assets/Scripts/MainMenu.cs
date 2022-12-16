using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Levels");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenStore()
    {
        SceneManager.LoadScene("Shop");
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OpenLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }


    // Levels
    public void OpenIce()
    {
        SceneManager.LoadScene("Ice");
    }

    public void OpenDesert()
    {
        SceneManager.LoadScene("Desert");
    }

    public void OpenInfinite()
    {
        SceneManager.LoadScene("Infinite");
    }

    public void OpenGarden()
    {
        SceneManager.LoadScene("Garden");
    }
}
