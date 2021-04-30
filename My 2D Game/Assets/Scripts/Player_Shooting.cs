using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject Bullet;

    private float muzzelForce = 10f;

    public Player_Movement movementScript;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); 
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(Bullet, gameObject.transform.position, Quaternion.Euler(0, 0, movementScript.angle));
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletRb.transform.up * muzzelForce, ForceMode2D.Impulse);
    }


}
