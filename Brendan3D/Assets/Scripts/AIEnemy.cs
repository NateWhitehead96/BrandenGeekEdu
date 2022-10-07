using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // access to nav mesh stuff

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // thing that controls the AI
    public Transform player; // target for the enemy
    public int health; // uhh health :)
    public Animator anim; // transition to dying, or any other states we may have
    public bool dying; // to know when the enemy is dying
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // force the enemy to find player on start
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dying == false) // if we are not dying chase player
            agent.SetDestination(player.position); // make the agent move towards our player

        if(health <= 0 && dying == false) // enemy dies
        {
            //Destroy(gameObject);
            StartCoroutine(Dying());
        }
    }

    IEnumerator Dying()
    {
        dying = true;
        agent.ResetPath(); // stop it from chasing the player
        GetComponent<CapsuleCollider>().enabled = false;
        anim.SetBool("dying", true); // play the dying animation
        yield return new WaitForSeconds(3);
        Destroy(gameObject); // optional, will destroy the enemy
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
