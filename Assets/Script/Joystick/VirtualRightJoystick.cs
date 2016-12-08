using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualRightJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image BackGroundRightJoystick;
    private Image RightJoystick;
    private Vector3 RightJostickInputVector;

    // initialise the two Image : BackGroundRightJoystick , RightJoystick
    private void Start()
    {
        BackGroundRightJoystick = GetComponent<Image>();
        RightJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    // fct when the user is still using the Right Joystick
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 positionLeftJoystick;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BackGroundRightJoystick.rectTransform, ped.position, ped.pressEventCamera, out positionLeftJoystick))
        {
            positionLeftJoystick.x = (positionLeftJoystick.x / BackGroundRightJoystick.rectTransform.sizeDelta.x);
            positionLeftJoystick.y = (positionLeftJoystick.y / BackGroundRightJoystick.rectTransform.sizeDelta.y);

            RightJostickInputVector = new Vector3(positionLeftJoystick.x * 2 + 1, 0, positionLeftJoystick.y * 2 - 1);
            RightJostickInputVector = (RightJostickInputVector.magnitude > 1.0f) ? RightJostickInputVector.normalized : RightJostickInputVector;

            RightJoystick.rectTransform.anchoredPosition = new Vector3(RightJostickInputVector.x * (BackGroundRightJoystick.rectTransform.sizeDelta.x / 4), RightJostickInputVector.z * (BackGroundRightJoystick.rectTransform.sizeDelta.y / 4));

            Debug.Log(RightJostickInputVector);
        }
    }

    // // fct start when user touch the Right Joystick
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    // fct start when user stop touching the Right Joystick
    public virtual void OnPointerUp(PointerEventData ped)
    {
        RightJostickInputVector = Vector3.zero;
        RightJoystick.rectTransform.anchoredPosition = Vector3.zero;
    }
    
    // this fct return the InputVectorPosition.x of the Left Joystick
    public float RightHorizontal()
    {
        if (RightJostickInputVector.x != 0)
        {
            return RightJostickInputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    // this fct return the InputVectorPosition.y of the Left Joystick
    public float RightVertical()
    {
        if (RightJostickInputVector.z != 0)
        {
            return RightJostickInputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
