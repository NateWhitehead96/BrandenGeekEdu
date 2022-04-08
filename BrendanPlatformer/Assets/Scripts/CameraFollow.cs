using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet; // a position we add to the player position to make sure the camera is looking at what we want
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPosition = player.position + offSet; // create a new position we want to follow
        transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime); // smoothly move towards the player
    }
}
