using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Assign the Rigidbody component
        rb.AddForce(force); // Apply the force set in the Inspector
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position); // Print the position of the sphere after every frame
    }
}

