using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float moveSpeed;
    public float offScreenLeft;
    public float offScreenRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

        if(transform.position.x <= offScreenLeft) // when it goes off screen to the left
        {
            transform.position = new Vector3(offScreenRight, transform.position.y); // teleport it back to the right
        }
    }
}
