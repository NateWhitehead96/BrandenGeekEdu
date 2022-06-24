using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public Slider sfxVolume;
    public Slider musicVolume;
    public Toggle screen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.instance.sfxVolume = sfxVolume.value;
        SoundManager.instance.musicVolume = musicVolume.value;

        Screen.fullScreen = screen.isOn; // will change the window to be full or not based on the toggle
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
