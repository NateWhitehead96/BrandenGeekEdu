using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public int increaseSunAmount;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime); // slowly move the sun down
        if (transform.position.y <= -6)
        {
            FindObjectOfType<PlantsManager>().suns += increaseSunAmount; // increase sun amount when the sun goes off screen
            Destroy(gameObject); // when the sun falls off screen, destroy
        }
    }
}
