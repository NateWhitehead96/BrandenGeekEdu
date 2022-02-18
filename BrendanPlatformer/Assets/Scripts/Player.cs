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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); // jumping into the air
            jumping = true;
        }

        animator.SetBool("isWalking", walking); // this controls the walking animation
        animator.SetBool("isJumping", jumping); // this controls the jumping animation

        if (Input.GetKey(KeyCode.W) && climbing == true) // climbing up the ladder
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) && climbing == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false; // when we collide with anything, we're on the "ground"
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder")) // when we touch the ladder, we're going to climb and have no gravity to help with that
        {
            climbing = true;
            rb.gravityScale = 0;
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
