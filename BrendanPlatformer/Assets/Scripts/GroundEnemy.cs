using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float moveSpeed;
    public float leftBounds;
    public float rightBounds;
    public float direction = -1; // the spider is by defualt facing left, which is the negative direction
    public SpriteRenderer sprite; // access to the renderer to flip the sprite based on direction
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // this is to make sure the sprite is linked
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * direction * Time.deltaTime, transform.position.y); // move enemy

        if(transform.position.x > rightBounds) // flip to go left
        {
            direction = -1;
            sprite.flipX = false;
        }
        if(transform.position.x < leftBounds) // flip to go right
        {
            direction = 1;
            sprite.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().health--; // when enemy collides with player, deal 1 damage
        }
    }
}
