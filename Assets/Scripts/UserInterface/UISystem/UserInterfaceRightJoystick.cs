using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserInterfaceRightJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public VirtualRightJoystick _rightJoystick;
    public Canvas _userInterface;
    public Image bG;
    public Image joyst;
    public bool _isJoystickRightUsed;

    private void Start()
    {
        this.gameObject.AddComponent<RectTransform>();
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
    }

    public virtual void OnPointerUp(PointerEventData pedRightJoystick)
    {
        _isJoystickRightUsed = false;
        _rightJoystick.ResetPosition();
    }

    public virtual void OnPointerDown(PointerEventData pedRightJoystick)
    {
        if(pedRightJoystick.position.x > Screen.width / 2)
        {
            bG.enabled = true;
            joyst.enabled = true;
            _isJoystickRightUsed = true;
            _rightJoystick.GetComponent<RectTransform>().position = new Vector2(pedRightJoystick.position.x, pedRightJoystick.position.y);
        }
        
    }

    public virtual void OnDrag(PointerEventData pedRightJoystick)
    {
        _rightJoystick.OnDrag(pedRightJoystick);
    }

    public bool IsJostickUsed
    {
        get { return _isJoystickRightUsed; }
    }
}
