using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPlay : MonoBehaviour {

    public Image _backGroundMenuGame;
    public Button _buttonPlay;
    public Text _buttonPlayText;

    
    void Start () {
        //_backGroundMenuGame = transform.FindChild("BackGroundMenuGame").GetComponent<Image>();
        //_buttonPlay = transform.FindChild("ButtonPlay").GetComponent<Button>();
        //_buttonPlayText = transform.FindChild("ButtonPlayText").GetComponent<Text>();

        _buttonPlayText.text = "Play";
    }
}
