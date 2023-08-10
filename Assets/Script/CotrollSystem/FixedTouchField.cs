using UnityEngine;
using UnityEngine.EventSystems;
public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;
    public float sensitivity = 0.5f; // Adjust this value to control sensitivity (lower value = less sensitive)

    public Transform targetCamera; // Reference to the camera you want to rotate
    public float rotationSpeed = 2.0f; // Adjust this value to control rotation speed

    void Update()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist = (Input.touches[PointerId].position - PointerOld) * sensitivity;
                PointerOld = Input.touches[PointerId].position;

                // Rotate the camera based on the vertical movement
                float rotationX = TouchDist.y * rotationSpeed;
                targetCamera.Rotate(Vector3.right, -rotationX);
            }
            else
            {
                TouchDist = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld) * sensitivity;
                PointerOld = Input.mousePosition;

                // Rotate the camera based on the vertical movement
                float rotationX = TouchDist.y * rotationSpeed;
                targetCamera.Rotate(Vector3.right, -rotationX);
            }
        }
        else
        {
            TouchDist = Vector2.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}