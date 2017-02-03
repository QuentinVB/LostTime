using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserInterfaceRightJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public VirtualRightJoystick _rightJoystick;
    public Image bG;
    public Image joyst;
    public bool _isJoystickRightUsed;

    private void Start()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2((GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 12),
            (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height));
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 12), 0);
    }

    public virtual void OnPointerUp(PointerEventData pedRightJoystick)
    {
        _isJoystickRightUsed = false;

        // Code Tutoriel
        if (PlayerPrefs.HasKey("TutorielRightJoystickComplete") == false)
        {
            if (GameObject.Find("TemporelleTutorielQuestController") == true)
            {
                if (GameObject.Find("TemporelleTutorielQuestController").GetComponent<TmpTutorielScript>().getSetTutorialStep < 2)
                {
                    GameObject.Find("TemporelleTutorielQuestController").GetComponent<TmpTutorielScript>().getSetTutorialStep = 2;
                }
            }
            PlayerPrefs.SetInt("TutorielRightJoystickComplete", 1);
        }
            
        //

        _rightJoystick.ResetPosition();
    }

    public virtual void OnPointerDown(PointerEventData pedRightJoystick)
    {
        if((pedRightJoystick.position.x > Screen.width / 2)
            && (GameObject.Find("GameMapPanel") == false)
            && (GameObject.Find("QuestBookPanel") == false)
            && (GameObject.Find("SystemConfigurationPanel") == false)
            && (GameObject.Find("InventoryBag") == false))
        {
            bG.enabled = true;
            joyst.enabled = true;
            _isJoystickRightUsed = true;
            _rightJoystick.GetComponent<RectTransform>().position = new Vector2(pedRightJoystick.position.x, pedRightJoystick.position.y);
        }
        
    }

    public virtual void OnDrag(PointerEventData pedRightJoystick)
    {
        if ((pedRightJoystick.position.x > Screen.width / 2)
            && (GameObject.Find("GameMapPanel") == false)
            && (GameObject.Find("QuestBookPanel") == false)
            && (GameObject.Find("SystemConfigurationPanel") == false)
            && (GameObject.Find("InventoryBag") == false))
        {
            _rightJoystick.OnDrag(pedRightJoystick);
        }
    }

    public bool IsJostickUsed
    {
        get { return _isJoystickRightUsed; }
    }
}
