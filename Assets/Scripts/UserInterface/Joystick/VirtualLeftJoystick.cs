using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualLeftJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image BackGroundLeftJoystick;
    private Image LeftJoystick;
    private Vector3 LeftJostickInputVector;

    // initialise the two Image : BackGroundLeftJoystick , LeftJoystick
    private void Start()
    {
        BackGroundLeftJoystick = GetComponent<Image>();
        LeftJoystick = transform.GetChild(0).GetComponent<Image>();
        ResetPosition();
    }

    public void ResetPosition()
    {
        BackGroundLeftJoystick.enabled = false;
        LeftJoystick.enabled = false;
    }

    // fct when the user is still using the Left Joystick
    public virtual void OnDrag(PointerEventData pedLeftJoystick)
    {
        Vector2 positionJoystick;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BackGroundLeftJoystick.rectTransform, pedLeftJoystick.position, pedLeftJoystick.pressEventCamera, out positionJoystick))
        {
            positionJoystick.x = (positionJoystick.x / BackGroundLeftJoystick.rectTransform.sizeDelta.x);
            positionJoystick.y = (positionJoystick.y / BackGroundLeftJoystick.rectTransform.sizeDelta.y);

            LeftJostickInputVector = new Vector3(positionJoystick.x * 2 + 1, 0, positionJoystick.y * 2 - 1);
            LeftJostickInputVector = (LeftJostickInputVector.magnitude > 1.0f) ? LeftJostickInputVector.normalized : LeftJostickInputVector;

            LeftJoystick.rectTransform.anchoredPosition = new Vector3(LeftJostickInputVector.x * (BackGroundLeftJoystick.rectTransform.sizeDelta.x / 4), LeftJostickInputVector.z * (BackGroundLeftJoystick.rectTransform.sizeDelta.y / 4));

           // Debug.Log(LeftJostickInputVector);
        }
    }

    // fct start when user touch the Left Joystick
    public virtual void OnPointerDown(PointerEventData pedLeftJoystick)
    {
        OnDrag(pedLeftJoystick);
    }

    // fct start when user stop touching the Left Joystick
    public virtual void OnPointerUp(PointerEventData pedLeftJoystick)
    {
        LeftJostickInputVector = Vector3.zero;
        LeftJoystick.rectTransform.anchoredPosition = Vector3.zero;
    }

    // this fct return the InputVectorPosition.x of the Left Joystick
    public float LeftHorizontal()
    {
        if (LeftJostickInputVector.x != 0)
        {
            return LeftJostickInputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    // this fct return the InputVectorPosition.y of the Left Joystick
    public float LeftVertical()
    {
        if (LeftJostickInputVector.z != 0)
        {
            return LeftJostickInputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
