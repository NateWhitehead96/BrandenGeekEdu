using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // grants access to switching scenes aka levels

public class DoorScript : MonoBehaviour
{
    public int LevelToLoad; // this will point to the level we want to load
    public bool inDoor; // this will know whether the player is inside the door or not
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && inDoor == true) // when we press a key and we're in door
        {
            SceneManager.LoadScene(LevelToLoad); // load the next scene
        }
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
