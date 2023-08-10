using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public float upLimit = -45f; // Angle limit for looking up
    public float downLimit = 20f; // Angle limit for looking down

    private Transform cameraTransform;
    private float currentRotationX = 0f;

    private void Start()
    {
        cameraTransform = Camera.main.transform; // Assuming the main camera is used
        currentRotationX = cameraTransform.localRotation.eulerAngles.x;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Calculate the new vertical rotation
        currentRotationX -= mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, upLimit, downLimit);

        // Apply the new rotation to the camera
        cameraTransform.localRotation = Quaternion.Euler(currentRotationX, 0f, 0f);
    }
}
