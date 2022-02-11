using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int moveSpeed; // how fast our player can move
    public int jumpForce; // how high our player can jump
    public Rigidbody2D rb; // this is access to the physics body to help us jump

    public SpriteRenderer sprite; // link to the sprite of the object so we can flip it to face the right direction
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
        }
        if (Input.GetKey(KeyCode.A)) // when we hit the A key
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move to the left
            sprite.flipX = true; // flip the sprite to look left
        }
        if (Input.GetKeyDown(KeyCode.Space)) // when we hit the spacebar
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); // jumping into the air
        }
    }
}
