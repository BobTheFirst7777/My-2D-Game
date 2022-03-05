using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public ScriptableEnemy identity;

    [SerializeField] public float hp;
    [SerializeField] public float armour;
    [SerializeField] public float speed;
    [SerializeField] public string myName;
    [SerializeField] private scriptableWeapon myGun;
    [SerializeField] private float range;
    [SerializeField] private float muzzelForce;
    [SerializeField] public string movementAItype;

    [SerializeField] private Vector2 targetPos;
    [SerializeField] private Vector2 curPos;

    public Transform playerPosition;
    private Vector3 aimVector;
    private float aimAngle;


    private Vector2 John;
    private bool JohnSet;


    private void Start()
    {
        JohnSet = false;

        hp = identity.health;
        armour = identity.armour;
        speed = identity.speed;
        myName = identity.enemyName;
        myGun = identity.gun;

        muzzelForce = myGun.speed;
        range = myGun.range;

        movementAItype = identity.movementType;

        InvokeRepeating("enemyShoot", 1.0f, 2f);
    }

    private void FixedUpdate()
    {
        enemyMove(movementAItype);
    }

    private void enemyMove(string para)
    {
        switch (para)
        {
            case "Suicide":
                transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed*Time.deltaTime);
                break;
            case "Standard":
                if(Vector2.Distance(transform.position, playerPosition.position) > 0.8 * range)
                {
                    transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
                    JohnSet = false;
                }
                else
                {
                    if(JohnSet == false)
                    {
                        John = new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f));
                        JohnSet = true;
                    }
                    if (new Vector2(transform.position.x,transform.position.y) != John && JohnSet == true)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, John, speed * Time.deltaTime);
                    }
                    else
                    {
                        John = new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f));
                    }
                }
                break;
        }

    }




    private void enemyShoot()
    {
        aimVector = playerPosition.position - transform.position;
        aimAngle = Mathf.Atan2((aimVector).y, (aimVector).x) * Mathf.Rad2Deg - 90f;
        GameObject bulletInstance = Instantiate(myGun.bulletPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, aimAngle));
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bulletRb.transform.up * muzzelForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), bulletInstance.GetComponent<Collider2D>());

        bulletInstance.GetComponent<Bullet>().blob = myGun.range;
        bulletInstance.GetComponent<Bullet>().localDamage = myGun.damage;
    }



}
