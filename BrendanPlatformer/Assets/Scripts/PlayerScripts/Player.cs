using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables and stuff
    public int moveSpeed; // how fast our player can move
    public int jumpForce; // how high our player can jump
    public Rigidbody2D rb; // this is access to the physics body to help us jump
    // Render stuff
    public SpriteRenderer sprite; // link to the sprite of the object so we can flip it to face the right direction
    // Animation stuff
    public Animator animator; // the animation controller
    public bool walking; // help with transitioning to walking animation
    public bool jumping; // help with transitioning to jump animation
    public bool climbing; // help with climbing ladders

    //public int coins; // the coins we collect in a level
    public int health; // how much health we got

    public Transform Checkpoint; // respawn point

    public bool inWater; // to know if we're swimming or not

    public float fallDamageTimer; // when we stop touching ground start this counter, if it hits over 2 seconds deal damage to player
    public GameObject PauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (inWater == true)
        {
            jumping = false; // be able to infinite jump
        }
        if (Input.GetKey(KeyCode.D)) // when we hit the D key
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y); // move to the right
            sprite.flipX = false; // make the player face to the right (faces right by default)
            walking = true;
        }
        else if (Input.GetKeyUp(KeyCode.D)) // when we release the key, turn walking off
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.A)) // when we hit the A key
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move to the left
            sprite.flipX = true; // flip the sprite to look left
            walking = true;
        }
        else if (Input.GetKeyUp(KeyCode.A)) // when we release the key, turn walking off
        {
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false) // when we hit the spacebar and we aren't currently jumping
        {
            SoundManager.instance.jumpSound.Play();
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); // jumping into the air
            jumping = true;
            transform.parent = null;
        }

        animator.SetBool("isWalking", walking); // this controls the walking animation
        animator.SetBool("isJumping", jumping); // this controls the jumping animation

        // --------- climbing inputs ------------- //

        if (Input.GetKey(KeyCode.W) && climbing == true) // climbing up the ladder
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            animator.SetBool("isClimbing", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isClimbing", false);
        }
        if(Input.GetKey(KeyCode.S) && climbing == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            animator.SetBool("isClimbing", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isClimbing", false);
        }

        // ----------- fall damage stuff ----------------- //
        if(jumping == true && climbing == false)
        {
            fallDamageTimer += Time.deltaTime; // counting up the time we're falling
        }
        // pause inputs
        if(Input.GetKeyDown(KeyCode.P) && PauseCanvas.activeInHierarchy)
        {
            PauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.P) && !PauseCanvas.activeInHierarchy)
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator PlayerHurt()
    {
        animator.SetBool("isHurt", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isHurt", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false; // when we collide with anything, we're on the "ground"
        if (fallDamageTimer >= 2)
        {
            StartCoroutine(PlayerHurt()); // this will play our hurt animation
            health--; // decrease health by 1
            if (health < 0)
            {
                // typically we'd show game over or die
                health = 0; // for now make sure health cant go below 0
            }
            fallDamageTimer = 0;
        }
        else
            fallDamageTimer = 0;
        if(collision.gameObject.tag == "Hazard")
        {
            SoundManager.instance.hurtSound.Play(); // play the hurt sound
            StartCoroutine(PlayerHurt()); // this will play our hurt animation
            health--; // decrease health by 1
            if(health < 0)
            {
                // typically we'd show game over or die
                health = 0; // for now make sure health cant go below 0
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        jumping = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder")) // when we touch the ladder, we're going to climb and have no gravity to help with that
        {
            climbing = true;
            rb.gravityScale = 0;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            SoundManager.instance.pickupSound.Play(); // this will play the pickup sound
            GameManager.instance.Coins++; // increase coins by 1
            Destroy(collision.gameObject); // destroy the coin
        }
        if (collision.gameObject.CompareTag("Head"))
        {
            Destroy(collision.transform.parent.gameObject); // destroying the spider from the head hitbox
        }
        if(collision.gameObject.name == "Deathplane")
        {
            transform.position = Checkpoint.position; // when we collide with the deathplane, respawn player at last checkpoint
        }
        if(collision.gameObject.name == "Heart")
        {
            health++; // increase health by 1
            if(health > 3) // if we already have full health, just set health to 3
            {
                health = 3;
            }
            Destroy(collision.gameObject); // destroy the heart after we touch it
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder")) // we left the ladder, gravity is back and we aren't climbing no more
        {
            climbing = false;
            rb.gravityScale = 1;
        }
    }
}
