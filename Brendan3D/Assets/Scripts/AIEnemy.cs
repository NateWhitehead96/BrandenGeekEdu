using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // access to nav mesh stuff

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // thing that controls the AI
    public Transform player; // target for the enemy
    public int health; // uhh health :)
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // force the enemy to find player on start
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position); // make the agent move towards our player

        if(health <= 0) // enemy dies
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()) // if the enemy is hit by bullet
        {
            print("hit");
            health -= 1; // lose health
            Destroy(collision.gameObject);
        }
    }
}
