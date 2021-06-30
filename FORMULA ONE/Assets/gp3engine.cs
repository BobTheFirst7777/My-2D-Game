using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gp3engine : MonoBehaviour
{
    Rigidbody2D rb;


    private float v;
    private float h;
    private float power = 10f;
    private Vector2 acceleration;

    private float brakeForce = 0.3f;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            v = 1;
        }
        else
        {
            v = 0;
        }

        
        if (Input.GetMouseButton(1) && Vector2.Angle(transform.up, rb.velocity) == 0)
        {
            rb.drag += brakeForce;
        }
        else
        {
            rb.drag = 0;
        }

        h = -Input.GetAxis("Horizontal");

        Debug.Log(Vector2.Dot(rb.velocity, (Vector2.up)));

        rb.rotation += h * 1;





        acceleration = transform.up * v * power;
        rb.AddForce(acceleration);

    }


}



