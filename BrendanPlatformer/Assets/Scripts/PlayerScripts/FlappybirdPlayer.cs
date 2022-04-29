using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappybirdPlayer : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;

    public int coinsCollected;

    public GameObject deathScreen;
    public GameObject PauseCanvas;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deathScreen.SetActive(false);
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
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

        if(rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 15);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -15);
        }

        if (Input.GetKeyDown(KeyCode.P) && PauseCanvas.activeInHierarchy)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
