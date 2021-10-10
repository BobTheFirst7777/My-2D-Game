using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private scriptableWeapon weapon;
    public Player_Movement movementScript;

    [SerializeField] private float muzzelForce;
    [SerializeField] private float range;


    private void Start()
    {
        muzzelForce = weapon.speed;
        range = weapon.range;
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); 
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(weapon.bulletPrefab, gameObject.transform.position,
                                                Quaternion.Euler(0, 0, movementScript.angle));
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletRb.transform.up * muzzelForce, ForceMode2D.Impulse);
        bulletInstance.GetComponent<Bullet>().blob = weapon.range;
    }

}
