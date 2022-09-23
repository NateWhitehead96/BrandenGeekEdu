using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float xRotation; // rotation in x axis
    public float rotationSpeed; // speed

    public GameObject bullet; // access to our bullet
    public Transform shootPoint; // where the bullet spawns from
    public float shootForce; // how much force the bullet should have (velocity)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Shoot();
    }

    public void RotateGun() // rotate the gun up and down
    {
        float mouseY = Input.GetAxis("Mouse Y"); // get the mouse y pos
        xRotation = mouseY * rotationSpeed * Time.deltaTime; // set our x rotation
        Vector3 gunRotation = transform.rotation.eulerAngles; // store the rotation
        gunRotation.x -= xRotation; // set the x rotation
        gunRotation.x = (gunRotation.x > 180) ? gunRotation.x - 360 : gunRotation.x; // determine if the angle is up or down
        gunRotation.x = Mathf.Clamp(gunRotation.x, -80, 80); // clamp the rotation to be either 80 or -80
        transform.rotation = Quaternion.Euler(gunRotation); // apply rotations
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) // left click to shoot
        {
            GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation); // spawn the bullet
            newBullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce, ForceMode.Impulse); // add firepower to the bullet
        }
    }
}
