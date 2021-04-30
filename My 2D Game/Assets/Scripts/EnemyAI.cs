using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject enemyBullet;

    private float muzzelForce = 10f;

    public Transform playerLocation;

    private void Start()
    {

        InvokeRepeating("enemyShoot", 1.0f, 2f);        

    }


    void enemyShoot()
    {
        GameObject bulletInstance = Instantiate(enemyBullet, gameObject.transform.position + (transform.up.normalized*0.1f), Quaternion.identity);
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletRb.transform.up * muzzelForce, ForceMode2D.Impulse);
    }



}
