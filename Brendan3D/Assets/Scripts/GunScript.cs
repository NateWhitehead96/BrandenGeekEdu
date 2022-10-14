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
    public int ammo; // how much ammo we have
    public int maxAmmo; // how much this gun's max ammo is
    bool shooting; // just to help with stuff
    public float rateOfFire; // how fast this gun shoots
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
        if (Input.GetMouseButton(0) && ammo > 0 && shooting == false) // left click to shoot
        {
            StartCoroutine(FireBullet());
            
            CancelInvoke(); // cancel the reloading just in case
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            //StartCoroutine(Reload());
            InvokeRepeating("ReloadGun", 0.5f, 0.5f); // repeat this function
        }
    }

    IEnumerator FireBullet()
    {
        shooting = true;
        GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation); // spawn the bullet
        newBullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce, ForceMode.Impulse); // add firepower to the bullet
        ammo--; // lower ammo by 1
        yield return new WaitForSeconds(rateOfFire);
        shooting = false;
    }

    public void ReloadGun() // reload 1 bullet at a time
    {
        if(ammo < maxAmmo)
        {
            ammo++;
        }
        else // when we've gained enough ammo stop
        {
            CancelInvoke();
        }
    }

}
