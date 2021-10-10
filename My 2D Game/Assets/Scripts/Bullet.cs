using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 previousLoc;
    public float distanceTravelled;
    public float blob;

    private void Start()
    {
        previousLoc = transform.position;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
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
