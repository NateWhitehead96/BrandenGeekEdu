using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    public int costToOpen;
    public bool opened; // have we unlocked this portal
    public bool inDoor;
    public SpriteRenderer sprite;
    public Sprite openDoor;
    public Animator fadeCanvasAnimator;

    public int levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (opened)
        {
            sprite.sprite = openDoor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inDoor && opened == false)
        {
            if (Input.GetKeyDown(KeyCode.W) && GameManager.instance.Coins >= costToOpen)
            {
                opened = true;
                // set something in the gamemanager
                GameManager.instance.Coins -= costToOpen; // subtract the cost
                // set the portal to show
                sprite.sprite = openDoor;
            }
        }
        else if(opened && Input.GetKeyDown(KeyCode.W) && inDoor)
        {
            StartCoroutine(FadeToNextLevel());
            print("opening new scene");
        }
    }
    IEnumerator FadeToNextLevel() // play the fade animation
    {
        fadeCanvasAnimator.SetBool("Fade", true); // we're setting it to fade
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelLoader); // load the next scene
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
