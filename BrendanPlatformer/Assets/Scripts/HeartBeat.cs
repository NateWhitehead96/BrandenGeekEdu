using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public float beatSpeed; // how fast it grows/shrinks

    public float maxSize;
    public float minSize;

    public float size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + beatSpeed * Time.deltaTime, transform.localScale.y + beatSpeed * Time.deltaTime);

        if(transform.localScale.x > maxSize)
        {
            beatSpeed *= -1; // flip the speed
        }
        if(transform.localScale.x < minSize)
        {
            beatSpeed *= -1;
        }
    }
}
