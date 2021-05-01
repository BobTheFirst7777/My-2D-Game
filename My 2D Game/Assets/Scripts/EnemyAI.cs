using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform playerPosition;
    private Vector3 aimVector;
    private float aimAngle;
    public GameObject enemyBullet;

    float muzzelForce = 10f;

    private void Start()
    {

        InvokeRepeating("enemyShoot", 1.0f, 2f);

    }


    void enemyShoot()
    {
        aimVector = playerPosition.position - transform.position;
        aimAngle = Mathf.Atan2((aimVector).y, (aimVector).x) * Mathf.Rad2Deg - 90f;
        GameObject bulletInstance = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.Euler(0, 0, aimAngle));
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletRb.transform.up * muzzelForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), bulletInstance.GetComponent<Collider2D>());
    }



}
