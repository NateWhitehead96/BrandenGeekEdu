using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("PlantSelector");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
