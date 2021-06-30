using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Suspension")]
    public float restLength;
    public float springTravel;
    public float springStiffness;

    private float maxLength;
    private float minLength;
    private float springLength;
    private float springForce;
    private float suspensionForce;


    [Header("Wheel")]
    public float wheelRadius;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        maxLength = restLength + springTravel;
        minLength = restLength - springTravel;
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hitData, maxLength + wheelRadius))
        {
            springLength = hitData.distance - wheelRadius;
            springForce = springStiffness * (restLength - springLength);

        }
    }
}
