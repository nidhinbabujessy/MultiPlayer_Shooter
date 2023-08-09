using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed = 100.0f; // Adjust this value for rotation speed
    public float moveSpeed = 5.0f;
    public FixedJoystick controller;
    public Transform cam;

    private void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleRotation()
    {
        float rotationInput = controller.Horizontal;

        // Calculate the rotation amount based on input and speed
        float rotationAmount = rotationInput * rotateSpeed * Time.deltaTime;

        // Apply the rotation around the Y-axis
        transform.Rotate(Vector3.up, rotationAmount);
    }

    private void HandleMovement()
    {
        float horizontalInput = controller.Vertical;
        float verticalInput = -controller.Horizontal; // Invert for correct movement

        Vector3 moveDirection = cam.forward * verticalInput + cam.right * horizontalInput;
        moveDirection.y = 0.0f;
        moveDirection.Normalize();

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
