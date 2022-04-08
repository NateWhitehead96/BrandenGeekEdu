using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // grants access to switching scenes aka levels

public class DoorScript : MonoBehaviour
{
    public int LevelToLoad; // this will point to the level we want to load
    public bool inDoor; // this will know whether the player is inside the door or not

    public bool unlocked; // to tell us if this portal has been unlocked
    public Animator fadeCanvasAnimator; // the animation controller on the image/panel we are using to fade

    // Start is called before the first frame update
    void Start()
    {
        //if(GameManager.instance.LevelsBeaten >= LevelToLoad - 1) // if we've beaten enough levels
        //{
        //    unlocked = true; 
        //}
        //if(unlocked == false)
        //{
        //    gameObject.SetActive(false); // hide the gameobject from view
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && inDoor == true) // when we press a key and we're in door
        {
            StartCoroutine(FadeToNextLevel());
        }

    }

    IEnumerator FadeToNextLevel() // play the fade animation
    {
        fadeCanvasAnimator.SetBool("Fade", true); // we're setting it to fade
        GameManager.instance.SaveGame(); // save coin value
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(LevelToLoad); // load the next scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = true; // player is inside/touching the door
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = false; // player has left the door
        }
    }
}
