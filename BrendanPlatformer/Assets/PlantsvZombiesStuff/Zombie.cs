using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private float maxSpeed; // even thos this is private and no other script can access, we can still see in inspector
    public int health;

    public Plant plantToAttack; // this will know what plant to fight when it comes near one

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move left
        
        if(health <= 0)
        {
            // we'll also count down on enemies remaining later
            Destroy(gameObject);
        }
        if(transform.position.x <= -12)
        {
            FindObjectOfType<PlantsManager>().GameOverCanvas.SetActive(true); // access the game over canvas from gamemanager
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<Plant>())
        {
            moveSpeed = 0; // stop the zombie from slamming into the plant
            plantToAttack = collision.gameObject.GetComponent<Plant>(); // assign the plant the zombie hit to our "target" plant
            InvokeRepeating("DamagePlant", 1, 1); // this will call the function DamagePlant every second for 1 second
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Plant>())
        {
            moveSpeed = maxSpeed; // again to make it move
            CancelInvoke(); // stop the attacking invoke
            plantToAttack = null; // reset the plant
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>()) // if the zombie is colliding with another zombie slow movespeed
        {
            moveSpeed = 0.1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>()) // if zombie is no longer touching zombie set speed back to normal
        {
            moveSpeed = maxSpeed;
        }
    }

    void DamagePlant()
    {
        plantToAttack.health--;
        if(plantToAttack.health <= 0)
        {
            plantToAttack.tile.isOccupied = false; // reopen up this tile for other plants
            Destroy(plantToAttack.gameObject);
            moveSpeed = maxSpeed; // reset movespeed for zombie
            plantToAttack = null; // make sure the zombie doesnt try to access a deleted thing
            CancelInvoke(); // stop damaging plant
        }
    }
}
