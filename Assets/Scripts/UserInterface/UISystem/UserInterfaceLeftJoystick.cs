using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserInterfaceLeftJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public VirtualLeftJoystick _leftJoystick;
    public Image bG;
    public Image joyst;
    private bool _isJoystickLeftUsed;

    private void Start()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2((GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 12),
            (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height));
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2((GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 12), 0);

        //this.GetComponent<RectTransform>().sizeDelta = new Vector2((GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2) + 1, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height);
        
    }

    public virtual void OnPointerUp(PointerEventData pedLeftJoystick)
    {
        _isJoystickLeftUsed = false;
        _leftJoystick.ResetPosition();
    }

    public virtual void OnPointerDown(PointerEventData pedLeftJoystick)
    {
        if((pedLeftJoystick.position.x < Screen.width / 2 )
            && (GameObject.Find("GameMapPanel") == false)
            && (GameObject.Find("QuestBookPanel") == false)
            && (GameObject.Find("SystemConfigurationPanel") == false)
            && (GameObject.Find("InventoryBag") == false))
        {
            bG.enabled = true;
            joyst.enabled = true;
            _isJoystickLeftUsed = true;
            _leftJoystick.GetComponent<RectTransform>().position = new Vector2(pedLeftJoystick.position.x, pedLeftJoystick.position.y);
        }
        
    }

    public virtual void OnDrag(PointerEventData pedLeftJoystick)
    {
        if ((pedLeftJoystick.position.x < Screen.width / 2)
            && (GameObject.Find("GameMapPanel") == false)
            && (GameObject.Find("QuestBookPanel") == false)
            && (GameObject.Find("SystemConfigurationPanel") == false)
            && (GameObject.Find("InventoryBag") == false))
        {
            _leftJoystick.OnDrag(pedLeftJoystick);
        }
            
    }

    public bool IsJostickUsed
    {
        get { return _isJoystickLeftUsed; }
    }
}
