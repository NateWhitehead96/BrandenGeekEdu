using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public Animator fadeAnimation;

    private void Start()
    {
        //fadeAnimation = FindObjectOfType<LevelDoor>().fadeCanvasAnimator; // set our animator
    }
    public void ResetSave()
    {
        if (PlayerPrefs.HasKey("Coins")) // make sure we have a save
        {
            PlayerPrefs.DeleteAll(); // delete all of our save data
            GameManager.instance.Coins = 0;

        }
    }
    public void OpenHUBWorld()
    {
        Time.timeScale = 1;
        StartCoroutine(FadeToNextLevel());
    }
    IEnumerator FadeToNextLevel() // play the fade animation
    {
        fadeAnimation.SetBool("Fade", true); // we're setting it to fade
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0); // load the next scene
    }
}
