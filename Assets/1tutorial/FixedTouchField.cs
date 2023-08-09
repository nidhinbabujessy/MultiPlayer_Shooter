using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

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

    void Start()
    {
    }

void Update()
{
    if (Pressed)
    {
        if (PointerId >= 0 && PointerId < Input.touches.Length)
        {
            TouchDist = (Input.touches[PointerId].position - PointerOld) * sensitivity;
            PointerOld = Input.touches[PointerId].position;
        }
        else
        {
            TouchDist = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld) * sensitivity;
            PointerOld = Input.mousePosition;
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