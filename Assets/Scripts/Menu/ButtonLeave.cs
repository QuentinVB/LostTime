using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLeave : MonoBehaviour {

    public Image _backGroundMenuGame;
    public Button _buttonLeave;
    public Text _buttonLeaveText;

    void Start () {
        //_backGroundMenuGame = transform.FindChild("BackGroundMenuGame").GetComponent<Image>();
        //_buttonLeave = transform.FindChild("ButtonLeave").GetComponent<Button>();
        //_buttonLeaveText = transform.FindChild("ButtonLeaveText").GetComponent<Text>();

        _buttonLeaveText.text = "Leave";
    }
	
	
}
