using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // how fast we move
    public Vector3 moveDirection; // help us know what direction we're moving
    public float yRotation; // the y rotation
    public float rotationSpeed; // how fast we rotate
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // keeps the mouse in the middle of the screen
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // movement function
        Rotate(); // rotating left and right
    }

    public void Move() // the movement for our player
    {
        float horizontal = Input.GetAxis("Horizontal"); // get any horizontal movements, left and right
        float vertical = Input.GetAxis("Vertical"); // get any vertical movements, forward and back
        moveDirection = (transform.forward * vertical) + (transform.right * horizontal); // calculate our forward move direction
        Vector3 force = moveDirection * speed * Time.deltaTime; // creating a force vector
        transform.position += force; // add the force to our position
    }

    public void Rotate() // vertical rotations of the player
    {
        float mouseX = Input.GetAxis("Mouse X"); // get our mouse x position
        yRotation = mouseX * rotationSpeed * Time.deltaTime; // set a new y rotation
        Vector3 playerRotation = transform.rotation.eulerAngles; // store our current rotation
        playerRotation.y += yRotation; // set the y rotation
        transform.rotation = Quaternion.Euler(playerRotation); // apply the rotations to our rotation
    }
}
