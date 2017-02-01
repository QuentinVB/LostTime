using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLanguagesFirstChoiceScript : MonoBehaviour {


    public Sprite _Cloud04;
    public Sprite _Cloud03;
    public Sprite _Cloud02;
    public Sprite _Cloud01;
    public Sprite _Storm;

    public Sprite _GameTittle;
    public Sprite _GameLogo;

    private GameObject _userInterface;

    public Sprite _Frenchgear;
    public Sprite _EnglishGear;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentLanguagesUsed") == true)
        {
            SceneManager.LoadScene("LostTimeMenuGame");
        }
        _userInterface = GameObject.Find("Canvas");

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SpriteOfCloud04", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width * 2, _userInterface.GetComponent<RectTransform>().rect.height * 1.5f, 0, 0, _Cloud04);
        GameObject.Find("SpriteOfCloud04").AddComponent<CloudsAnims>();

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SpriteOfCloud03", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width * 2, _userInterface.GetComponent<RectTransform>().rect.height * 1.5f, 0, 0, _Cloud03);
        GameObject.Find("SpriteOfCloud03").AddComponent<CloudsAnims>();

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SpriteOfStorm", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width * 2, _userInterface.GetComponent<RectTransform>().rect.height * 1.5f, 0, 0, _Storm);
        GameObject.Find("SpriteOfStorm").AddComponent<Storm>();

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SpriteOfCloud02", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width * 2, _userInterface.GetComponent<RectTransform>().rect.height * 1.5f, 0, 0, _Cloud02);
        GameObject.Find("SpriteOfCloud02").AddComponent<CloudsAnims>();

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SpriteOfCloud01", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width * 2, _userInterface.GetComponent<RectTransform>().rect.height * 1.5f, 0, 0, _Cloud01);
        GameObject.Find("SpriteOfCloud01").AddComponent<CloudsAnims>();

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("GameTittle", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 4,
            0, _userInterface.GetComponent<RectTransform>().rect.height / 2 - _userInterface.GetComponent<RectTransform>().rect.height / 8, _GameTittle);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("GameLogo", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.height, _userInterface.GetComponent<RectTransform>().rect.height, 0, 0, _GameLogo);
        GameObject.Find("GameLogo").GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.2f);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("FrenchButton", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width / 4, _userInterface.GetComponent<RectTransform>().rect.height / 8,
            0, _userInterface.GetComponent<RectTransform>().rect.height / 8, "Français", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("FrenchButton").AddComponent<Button>();
        GameObject.Find("FrenchButton").GetComponent<Button>().onClick.AddListener(() => FrenchButtonAction());

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("EnglishButton", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width / 4, _userInterface.GetComponent<RectTransform>().rect.height / 8,
            0, _userInterface.GetComponent<RectTransform>().rect.height / -8, "English", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("EnglishButton").AddComponent<Button>();
        GameObject.Find("EnglishButton").GetComponent<Button>().onClick.AddListener(() => EnglishButtonAction());

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("FirstFrenchGear", GameObject.Find("FrenchButton"), true,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height, GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.width / -2 - GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height / 2, 0, _Frenchgear);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SecondFrenchGear", GameObject.Find("FrenchButton"), true,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height, GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.width / 2 + GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height / 2, 0, _Frenchgear);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("FirstEnglishGear", GameObject.Find("EnglishButton"), true,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height, GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.width / -2 - GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height / 2, 0, _EnglishGear);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SecondEnglishGear", GameObject.Find("EnglishButton"), true,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height, GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.width / 2 + GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height / 2, 0, _EnglishGear);
    }

    private void Update()
    {
        GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("FirstFrenchGear", 0, 0, 0, 0, -1, 2);
        GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SecondFrenchGear", 0, 0, 0, 0, -1, 2);
        GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("FirstEnglishGear", 0, 0, 0, 0, -1, 2);
        GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SecondEnglishGear", 0, 0, 0, 0, -1, 2);
    }

    private void FrenchButtonAction()
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", "Français");
        SceneManager.LoadScene("LostTimeMenuGame");
    }

    private void EnglishButtonAction()
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", "Anglais");
        SceneManager.LoadScene("LostTimeMenuGame");
    }

}
