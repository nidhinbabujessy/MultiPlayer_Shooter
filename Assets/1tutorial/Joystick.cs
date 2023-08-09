using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image jsContainer;
    private Image joystick;

    public Vector3 InputDirection;

    public AnimatorContolle animatorController;  // Reference to AnimatorContolle script

    private bool isDraggingg = false;

    void Start()
    {
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        // Calculate local position of the joystick within the container
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            jsContainer.rectTransform,
            ped.position,
            ped.pressEventCamera,
            out position
        );

        // Normalize position within the joystick's bounds
        position.x = Mathf.Clamp(position.x / jsContainer.rectTransform.sizeDelta.x, -1f, 1f);
        position.y = Mathf.Clamp(position.y / jsContainer.rectTransform.sizeDelta.y, -1f, 1f);

        InputDirection = new Vector3(position.x, position.y, 0f);
        InputDirection = (InputDirection.magnitude > 1f) ? InputDirection.normalized : InputDirection;

        // Move the joystick handle
        joystick.rectTransform.anchoredPosition = new Vector3(
            InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3f),
            InputDirection.y * (jsContainer.rectTransform.sizeDelta.y / 3f)
        );

        if (InputDirection.x < 0f && !isDraggingg)  // Dragged left and not previously dragging
        {
            isDraggingg = true;
            animatorController.RunLeft();  // Trigger the RunLeft animation
        }

        else if (InputDirection.x > 0f && !isDraggingg)  // Dragged left and not previously dragging
        {
            isDraggingg = true;
            animatorController.RunRight();  // Trigger the RunLeft animation
        }
        else if (InputDirection.x == 0f && isDraggingg)  // Released joystick from left drag
        {
            isDraggingg = false;
            animatorController.idle();  // Stop the running animation
        }
        else if (InputDirection.y < 0f && isDraggingg)  // Released joystick from left drag
        {
            isDraggingg = true;
            animatorController.RunBack();  // Stop the running animation
        }
       else if (InputDirection.y > 0f && !isDraggingg)  // Dragged left and not previously dragging
        {
            isDraggingg = true;
            animatorController.playerRun();  // Trigger the RunLeft animation
        }
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;

        isDraggingg = false;  // Reset the dragging flag when joystick is released
        animatorController.idle();  // Stop the running animation
    }
}
