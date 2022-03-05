using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 previousLoc;
    public float distanceTravelled;
    public float blob;

    public float localDamage;

    private void Start()
    {
        previousLoc = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }


        switch (collision.gameObject.tag)
        {
            case "Enemy":
                if(collision.gameObject.GetComponent<EnemyAI>().hp - localDamage <= 0)
                {
                    collision.gameObject.GetComponent<EnemyAI>().hp -= localDamage;
                    Destroy(collision.gameObject);
                }
                else
                {
                    collision.gameObject.GetComponent<EnemyAI>().hp -= localDamage;
                }
                Destroy(gameObject);
                break;

            case "Player":
                if (collision.gameObject.GetComponent<Player_Controller>().playerHealth - localDamage <= 0)
                {
                    collision.gameObject.GetComponent<Player_Controller>().playerHealth -= localDamage;
                    Debug.Log("DEATH!");
                }
                else
                {
                    collision.gameObject.GetComponent<Player_Controller>().playerHealth -= localDamage;
                }
                Debug.Log(collision.gameObject.GetComponent<Player_Controller>().playerHealth);
                Destroy(gameObject);
                break;

            case "Bullet":
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
                break;

            default:
                break;
        }

    }

    private void FixedUpdate()
    {
        distanceTravelled += Vector3.Distance(transform.position, previousLoc);
        previousLoc = transform.position;
        if (distanceTravelled > blob)
        {
            Destroy(gameObject);
        }
    }

    /*
    public void deathSentence(float pog)
    {
        if (distanceTravelled>=pog)
        {
            Debug.Log("Why");
        }
    }
    */

}
