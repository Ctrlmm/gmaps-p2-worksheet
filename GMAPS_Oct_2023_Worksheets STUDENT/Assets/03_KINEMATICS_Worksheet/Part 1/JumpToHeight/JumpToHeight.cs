using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity initially
    }

    void Jump()
    {
        float gravityMagnitude = Physics.gravity.magnitude;
        float initialVelocity = Mathf.Sqrt(2 * gravityMagnitude * Height);
        rb.velocity = new Vector3(0, initialVelocity, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true; // Enable gravity before jumping
            Jump();
        }
    }
}
