using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialogPNJController : MonoBehaviour {

    private GameObject _userInterface;
	void Start () {
        _userInterface = GameObject.Find("Canvas");

        CreateBackGroundTextBox();
        CreateTextBoxTextZone();
    }

    private void CreateBackGroundTextBox()
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("TextBoxBackGround", GameObject.Find("Canvas"), true,
            GameObject.Find("BackGroundLeftInterface").GetComponent<RectTransform>().rect.width,
            (GameObject.Find("BackGroundLeftInterface").GetComponent<RectTransform>().rect.height / 10) * 3,
            0, (GameObject.Find("BackGroundLeftInterface").GetComponent<RectTransform>().rect.height / 10) * -3.5f,
            Color.black);
    }

    private void CreateTextBoxTextZone()
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("TextBoxTextZone", GameObject.Find("TextBoxBackGround"), true,
            GameObject.Find("TextBoxBackGround").GetComponent<RectTransform>().rect.width,
            GameObject.Find("TextBoxBackGround").GetComponent<RectTransform>().rect.height,
            0, 0, "Forgeron : Salutation Voyageur, j'ai perdu mon unique marteau. \r\nJ'en ai vraiment besoin pour travailler.\r\nPeux tu me le retrouver? \r\nMerci beaucoup pour ton aide",
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter, FontStyle.Normal, 
            (int)(GameObject.Find("TextBoxBackGround").GetComponent<RectTransform>().rect.height / 7.5f), Color.white);
    }
}
