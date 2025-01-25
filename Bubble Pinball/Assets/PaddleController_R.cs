using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController_R : MonoBehaviour
{
    public KeyCode activationKey = KeyCode.Q;  // Key to trigger paddle rotation
    public float rotationAngle = 30f;          // The angle to rotate counterclockwise
    public float rotationSpeed = 200f;         // Speed of the rotation
    public float forceMagnitude = 10f;         // The force applied to the ball

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool rotatingForward = false;
    private bool rotatingBack = false;
    private bool forceApplied = false;

    void Start()
    {
        // Store the initial rotation of the paddle
        initialRotation = transform.parent.rotation;
        targetRotation = Quaternion.Euler(0, 0, transform.parent.eulerAngles.z + rotationAngle);
    }

    void Update()
    {
        // When pressing Q, start rotating forward if not already rotating
        if (Input.GetKeyDown(activationKey) && !rotatingForward && !rotatingBack)
        {
            rotatingForward = true;
            forceApplied = false;  // Reset force application
        }


    }

    void FixedUpdate(){
        // Rotate forward to the target angle
        if (rotatingForward)
        {
            RotatePaddle(targetRotation, ref rotatingForward, true);
        }

        // Rotate back to the original position
        if (rotatingBack)
        {
            RotatePaddle(initialRotation, ref rotatingBack, false);
        }
    }

    void RotatePaddle(Quaternion targetRot, ref bool rotatingFlag, bool returning)
    {
        float step = rotationSpeed * Time.deltaTime;
        transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, targetRot, step);

        // Check if rotation is complete
        if (Quaternion.Angle(transform.parent.rotation, targetRot) < 0.1f)
        {
            transform.parent.rotation = targetRot;
            rotatingFlag = false;

            // If rotation was forward, start returning back
            if (returning)
            {
                rotatingBack = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Apply force only if paddle is rotating forward and has not applied force yet
        if (collision.gameObject.CompareTag("Player") && rotatingForward && !forceApplied)
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                // Calculate force direction perpendicular to paddle, with a downward component
                Vector3 forceDirection = -transform.up;
                forceDirection.Normalize();

                // Apply impulse force to the ball
                ballRb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                forceApplied = true;  // Ensure force is applied only once per rotation cycle
            }
        }
    }
}

