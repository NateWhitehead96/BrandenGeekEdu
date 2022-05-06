using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // move the pea to the right

        if(transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
