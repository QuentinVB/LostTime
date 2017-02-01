using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiChoiceScript : MonoBehaviour {

    private GameObject _userInterface;
    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
    }


    public void setMultichoiceAction(int numberOfChoice, string firstText, string secondText, string ThirdText, string FourthText)
    {
        if(GameObject.Find("MultiChoicePanelBackGround") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("MultiChoicePanelBackGround", _userInterface, true, _userInterface.GetComponent<RectTransform>().rect.height / 2,
            _userInterface.GetComponent<RectTransform>().rect.height / 2, 0, 0, Color.white);

            switch (numberOfChoice)
            {
                case 2:
                    setMultiChoiceForTwoText(firstText, secondText);
                    break;
                case 3:
                    setMultiChoiceForThreeText(firstText, secondText, ThirdText);
                    break;
                case 4:
                    setMultiChoiceForFourText(firstText, secondText, ThirdText, FourthText);
                    break;
                default:
                    setOneChoice(firstText);
                    break;
            }
        }else
        {
            Destroy(GameObject.Find("MultiChoicePanelBackGround"));
        }
        
        
    }

    private void setOneChoice(string firstText)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetFirstChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            0, 0, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetFirstChoiceText", GameObject.Find("SetFirstChoiceBackGround"), true,
            GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            firstText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetFirstChoiceText").AddComponent<Button>();
        GameObject.Find("SetFirstChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(firstText));
    }

    private void setMultiChoiceForTwoText(string firstText, string secondText)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetFirstChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / -2, 0, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetFirstChoiceText", GameObject.Find("SetFirstChoiceBackGround"), true,
            GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            firstText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetFirstChoiceText").AddComponent<Button>();
        GameObject.Find("SetFirstChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(firstText));


        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetSecondChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, 0, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetSecondChoiceText", GameObject.Find("SetSecondChoiceBackGround"), true,
            GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            secondText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetSecondChoiceText").AddComponent<Button>();
        GameObject.Find("SetSecondChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(secondText));
    }

    private void setMultiChoiceForThreeText(string firstText, string secondText, string ThirdText)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetFirstChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / -2, 0, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetFirstChoiceText", GameObject.Find("SetFirstChoiceBackGround"), true,
            GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            firstText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetFirstChoiceText").AddComponent<Button>();
        GameObject.Find("SetFirstChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(firstText));

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetSecondChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, 0, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetSecondChoiceText", GameObject.Find("SetSecondChoiceBackGround"), true,
            GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            secondText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetSecondChoiceText").AddComponent<Button>();
        GameObject.Find("SetSecondChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(secondText));

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetThirdChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            0, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / -2, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetThirdChoiceText", GameObject.Find("SetThirdChoiceBackGround"), true,
            GameObject.Find("SetThirdChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetThirdChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            ThirdText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetThirdChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetThirdChoiceText").AddComponent<Button>();
        GameObject.Find("SetThirdChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(ThirdText));
    }

    private void setMultiChoiceForFourText(string firstText, string secondText, string ThirdText, string FourthText)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetFirstChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / -2, 0, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetFirstChoiceText", GameObject.Find("SetFirstChoiceBackGround"), true,
            GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            firstText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetFirstChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetFirstChoiceText").AddComponent<Button>();
        GameObject.Find("SetFirstChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(firstText));


        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetSecondChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, 0, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetSecondChoiceText", GameObject.Find("SetSecondChoiceBackGround"), true,
            GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            secondText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetSecondChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetSecondChoiceText").AddComponent<Button>();
        GameObject.Find("SetSecondChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(secondText));


        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetThirdChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            0, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / -2, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetThirdChoiceText", GameObject.Find("SetThirdChoiceBackGround"), true,
            GameObject.Find("SetThirdChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetThirdChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            ThirdText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetThirdChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetThirdChoiceText").AddComponent<Button>();
        GameObject.Find("SetThirdChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(ThirdText));


        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SetFourthChoiceBackGround", GameObject.Find("MultiChoicePanelBackGround"), true,
            GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 5,
            0, GameObject.Find("MultiChoicePanelBackGround").GetComponent<RectTransform>().rect.height / 2, Color.grey);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SetFourthChoiceText", GameObject.Find("SetFourthChoiceBackGround"), true,
            GameObject.Find("SetFourthChoiceBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("SetFourthChoiceBackGround").GetComponent<RectTransform>().rect.height, 0, 0,
            FourthText, GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("SetFourthChoiceBackGround").GetComponent<RectTransform>().rect.height / 4)), Color.black);
        GameObject.Find("SetFourthChoiceText").AddComponent<Button>();
        GameObject.Find("SetFourthChoiceText").GetComponent<Button>().onClick.AddListener(() => ReturnText(FourthText));
    }

    private string ReturnText(string text)
    {
        Debug.Log(text);
        Destroy(GameObject.Find("MultiChoicePanelBackGround"));
        return text;
    }
}
