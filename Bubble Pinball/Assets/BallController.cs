using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float acceleration = 1f;   // Acceleration force applied when arrow keys are pressed
    public float maxControlSpeed = 2f; // Maximum speed the player can control in horizontal direction

    private Rigidbody rb;
  

    void Start()
    {
        // Get the Rigidbody component attached to the ball
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        // Get input from left and right arrow keys
        float moveInput = Input.GetAxis("Horizontal");  // -1 (left), 0 (no input), 1 (right)
        
        if (moveInput != 0)
        {
            // Apply gradual force to move the ball in the horizontal direction
            rb.AddForce(Vector3.left * moveInput * acceleration, ForceMode.Acceleration);
            
            // Optional: Limit player-controlled speed but allow external forces to exceed it
            if (Mathf.Abs(rb.velocity.x) > maxControlSpeed)
            {
                float clampedSpeed = Mathf.Sign(rb.velocity.x) * maxControlSpeed;
                rb.velocity = new Vector3(clampedSpeed, rb.velocity.y, rb.velocity.z);
            }
        }
    }
}
