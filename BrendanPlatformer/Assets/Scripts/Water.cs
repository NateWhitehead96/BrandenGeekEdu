using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public int waterJumpForce; // how high we can jump in the water
    public float waterGravity; // how much gravity is there in the water

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Player player = GetComponent<Player>(); // local variable, to help access player easier
            player.jumpForce = waterJumpForce; // set the jumpforce
            player.GetComponent<Rigidbody2D>().gravityScale = waterGravity; // set the gravity
            player.inWater = true; // to allow the player to constantly jump
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Player player = GetComponent<Player>(); // local variable, to help access player easier
            player.jumpForce = 5; // set the jumpforce
            player.rb.gravityScale = 1; // set the gravity
            player.inWater = false; // player is jumping out of water
        }
    }
}
