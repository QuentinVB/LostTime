using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackGroundMenu : MonoBehaviour {

    public Image _backGroundMenu;

    void Start () {
        //_backGroundMenu = transform.FindChild("BackGroundMenu").GetComponent<Image>();
        _backGroundMenu.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
	
	
}
