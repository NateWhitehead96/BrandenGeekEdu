using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappybirdPlayer : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // every time we hit space, we jump
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            //anim.SetBool("isJumping", true);
        }
    }
}
