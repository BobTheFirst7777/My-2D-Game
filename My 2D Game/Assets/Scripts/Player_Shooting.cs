using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private scriptableWeapon weapon;
    public Player_Controller movementScript;
    [SerializeField] private LineRenderer bulletVFX;

    [SerializeField] private float muzzelForce;
    [SerializeField] private float range;
    [SerializeField] private bool isFiring;
    [SerializeField] private float dexRate;
    [SerializeField] private string weaponType;

    [SerializeField] private Vector3 myMouse;





    private void Start()
    {
        muzzelForce = weapon.speed;
        range = weapon.range;
        dexRate = weapon.fireRate;
        weaponType = weapon.weaponType;

        bulletVFX.enabled = false;

        isFiring = false;
    }


    private void Update()
    {
        switch (weaponType)
        {
            case "Sword":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isFiring == true)
                    {
                        isFiring = false;
                        CancelInvoke();
                    }
                    else
                    {
                        InvokeRepeating("ShootSword", 0, 1 / dexRate);
                        isFiring = true;
                    }
                }
                break;

            case "Gun":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isFiring == true)
                    {
                        isFiring = false;
                        CancelInvoke();
                    }
                    else
                    {
                        StartCoroutine(ShootBullet(1/dexRate));
                        isFiring = true;
                    }
                }
                break;

            default:
                break;

        }





    }

    private void ShootSword()
    {
        GameObject bulletInstance = Instantiate(weapon.bulletPrefab, gameObject.transform.position,
                                                Quaternion.Euler(0, 0, movementScript.angle));
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletRb.transform.up * muzzelForce, ForceMode2D.Impulse);

        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), bulletInstance.GetComponent<Collider2D>());

        bulletInstance.GetComponent<Bullet>().blob = weapon.range;
        bulletInstance.GetComponent<Bullet>().localDamage = weapon.damage;
    }




    IEnumerator ShootBullet(float tim)
    {
        while (true)
        {
            myMouse = new Vector3(movementScript.mousePos.x,movementScript.mousePos.y,0)-gameObject.transform.position;
            myMouse.Normalize();
            Debug.Log("HENLO");
            bulletVFX.enabled = true;
            bulletVFX.SetPosition(0, gameObject.transform.position);
            bulletVFX.SetPosition(1, myMouse*100);
            yield return new WaitForSeconds(0.04f);
            bulletVFX.enabled = false;
            yield return new WaitForSeconds(tim);
        }

    }

}
