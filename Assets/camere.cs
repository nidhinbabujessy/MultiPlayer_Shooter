using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;             // Reference to the target object (player)
    public float smoothSpeed = 0.125f;   // Speed at which the camera follows the target
    public Vector3 offset;               // Offset from the target's position

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Make the camera look at the target
    }
}
