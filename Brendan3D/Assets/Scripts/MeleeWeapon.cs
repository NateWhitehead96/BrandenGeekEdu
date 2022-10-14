using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float xRotation; // rotation in x axis
    public float rotationSpeed; // speed
    public bool attacking; // to know if we are swigning the weapon
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();
        SwingWeapon();
    }

    public void SwingWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
            attacking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
            attacking = false;
        }
    }

    public void RotateWeapon()
    {
        float mouseY = Input.GetAxis("Mouse Y"); // get the mouse y pos
        xRotation = mouseY * rotationSpeed * Time.deltaTime; // set our x rotation
        Vector3 gunRotation = transform.rotation.eulerAngles; // store the rotation
        gunRotation.x -= xRotation; // set the x rotation
        gunRotation.x = (gunRotation.x > 180) ? gunRotation.x - 360 : gunRotation.x; // determine if the angle is up or down
        gunRotation.x = Mathf.Clamp(gunRotation.x, -80, 80); // clamp the rotation to be either 80 or -80
        transform.rotation = Quaternion.Euler(gunRotation); // apply rotations
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AIEnemy>()) // we only hurt the enemy if we're swinging the weapon
        {
            if(attacking == true)
            {
                collision.gameObject.GetComponent<AIEnemy>().health -= 5;
            }
        }
    }
}
