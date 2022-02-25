using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed; // how fast the coind goes up and down

    public float topBounds; // how high the coin can travel
    public float botBounds; // how low the coin can go
    public int direction = 1; // what direction the coin will go, 1 for up and -1 for down
    // Start is called before the first frame update
    void Start()
    {
        topBounds = transform.position.y + 0.5f; // top bounds will always be 0.5 units above
        botBounds = transform.position.y - 0.5f; // bottom bounds will always be 0.5 units below
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime); // move the coin

        if(transform.position.y > topBounds)
        {
            direction = -1; // flip direction to go down when we hit the top bounds
        }
        if(transform.position.y < botBounds)
        {
            direction = 1; // flip direction to go up when we hit bottom bounds
        }
    }
}
