using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject Pipes; // prefab of pipes
    public float top, bot; // bounds for top and bottom
    public float timer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // count up timer
        if(timer >= 5)
        {
            float newY = Random.Range(bot, top); // find a new y value
            Instantiate(Pipes, new Vector3(transform.position.x, newY), transform.rotation); // spawn at new random y
            timer = 0;
        }
    }
}
