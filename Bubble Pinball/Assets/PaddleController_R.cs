using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class PaddleController_R : MonoBehaviour
{
    [Header("Angles")]
    public float closedAngle = -30f;
    public float openedAngle = 30f;

    [Header("Motor Settings")]
    public float motorSpeed = -250f;   // Degrees per second
    public float motorForce = 1000f;  // How strong the motor is

    private HingeJoint hinge;
    private JointMotor motor;

    // Define states for clarity
    private enum FlipperState { Idle, MovingUp, MovingDown }
    private FlipperState currentState = FlipperState.Idle;

    private float currentAngle = 0f;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useMotor = false;

        // Initialize the motor with force
        motor = hinge.motor;
        motor.force = motorForce;
        motor.targetVelocity = 0;
        hinge.motor = motor;

        // Debug.Log("Flipper initialized. Motor off.");
    }

    void Update()
    {
        currentAngle = NormalizeAngle(transform.localEulerAngles.z);
        // Debug.Log($"Currenttttt paddle angle (localEulerAngles): {currentAngle}");
        // Debug.Log($"Current state: {currentState}");

        if (Input.GetKeyDown(KeyCode.Q) && currentState == FlipperState.Idle)
        {
            // Debug.Log("Q key pressed. Moving flipper down.");

            // Begin rotating "up" (towards openedAngle)
            currentState = FlipperState.MovingDown;
            hinge.useMotor = true;

            motor.targetVelocity = motorSpeed;
            hinge.motor = motor;
        }

        switch (currentState)
        {
            case FlipperState.MovingUp:
                // Debug.Log("Flipper is moving up.");

                // If we've reached or exceeded the openedAngle, switch to moving down
                if (Mathf.Abs(currentAngle - openedAngle) < 1.0f)
                {
                    // Debug.Log("Opened angle reached. Returning to Idle.");

                    currentState = FlipperState.Idle;
                    hinge.useMotor = false;
                    // motor.targetVelocity = -motorSpeed;
                    // hinge.motor = motor;
                }
                break;

            case FlipperState.MovingDown:
                // Debug.Log("Flipper is moving down.");
                // Debug.Log($"Current paddle angle and Closed angle: {currentAngle}, {openedAngle}");

                if (Mathf.Abs(currentAngle - closedAngle) < 1.0f)
                {
                    // Debug.Log("Closed angle reached. Switching to moving up.");

                    currentState = FlipperState.MovingUp;
                    motor.targetVelocity = -motorSpeed;
                    hinge.motor = motor;
                }
                break;
        }
    }

    // Helper function to normalize angles between -180 to 180 degrees
    private float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle > 180)
            angle -= 360;
        return angle;
    }
}
