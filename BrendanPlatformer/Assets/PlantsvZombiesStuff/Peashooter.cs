using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : MonoBehaviour
{
    public GameObject peaBullet; // prefab of the pea bullet
    public float timer;
    public float reloadSpeed; // how often the peashooter will shoot
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // count down on our timer
        if(timer <= 0)
        {
            Instantiate(peaBullet, transform.position, transform.rotation); // spawn the bullet
            timer = reloadSpeed; // reset timer
        }
    }
}
