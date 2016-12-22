using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackGroundMenuGame : MonoBehaviour {

    public Image _backGroundMenuGame;

    void Start () {
        //_backGroundMenuGame = transform.FindChild("BackGroundMenuGame").GetComponent<Image>();
        _backGroundMenuGame.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.height);
    }
	
}
