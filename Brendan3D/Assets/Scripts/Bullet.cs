using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 5); // destroy the bullet after its been on screen for 5 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); // destroy bullet if it hits the ground
        }
    }
}
