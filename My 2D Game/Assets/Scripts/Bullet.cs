using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool record = false;
    private Vector2 previousLoc;
    public float distanceTravelled = 0f;

    private void Start()
    {
        record = true;
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
        if (record)
        {
            distanceTravelled += Vector3.Distance(transform.position, previousLoc);
            previousLoc = transform.position;
        }
    }

    public void deathSentence(float range)
    {
        if (distanceTravelled>=range)
        {
            Destroy(gameObject);
        }
    }

}
