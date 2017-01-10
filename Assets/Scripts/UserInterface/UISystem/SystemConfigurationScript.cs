using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SystemConfigurationScript : MonoBehaviour, IPointerDownHandler
{

    private GameObject _SystemConfigurationPanel;
    private GameObject _userInterface;
    private GameObject _systemPanel;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _systemPanel = GameObject.Find("SystemPanel");
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("QuestBookPanel") == true)
        {
            Destroy(GameObject.Find("QuestBookPanel"));
        }
        if (GameObject.Find("GameMapPanel") == true)
        {
            Destroy(GameObject.Find("GameMapPanel"));
        }
        if (GameObject.Find("InventoryBag") == true)
        {
            Destroy(GameObject.Find("InventoryBag"));
        }

        if (GameObject.Find("SystemConfigurationPanel") == false)
        {
            _SystemConfigurationPanel = new GameObject("SystemConfigurationPanel");
            _SystemConfigurationPanel.AddComponent<RectTransform>();
            _SystemConfigurationPanel.transform.SetParent(_userInterface.gameObject.transform, true);
            _SystemConfigurationPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
            _SystemConfigurationPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            Image x = _SystemConfigurationPanel.AddComponent<Image>();
            x.color = Color.grey;
            _SystemConfigurationPanel.transform.SetParent(_systemPanel.gameObject.transform, true);

            GameObject _SystemConfigurationPanelLabel = new GameObject("_SystemConfigurationPanelLabel");
            _SystemConfigurationPanelLabel.AddComponent<RectTransform>();
            _SystemConfigurationPanelLabel.AddComponent<Button>();
            _SystemConfigurationPanelLabel.transform.SetParent(_SystemConfigurationPanel.transform, true);
            _SystemConfigurationPanelLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width), _SystemConfigurationPanel.GetComponent<RectTransform>().rect.height);
            _SystemConfigurationPanelLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            _SystemConfigurationPanelLabel.AddComponent<Text>();
            _SystemConfigurationPanelLabel.GetComponent<Text>().text = "Game Config";
            _SystemConfigurationPanelLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            _SystemConfigurationPanelLabel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            _SystemConfigurationPanelLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
            _SystemConfigurationPanelLabel.GetComponent<Text>().fontSize = (int)(gameObject.GetComponent<RectTransform>().rect.height / 2);
            _SystemConfigurationPanelLabel.GetComponent<Text>().color = Color.black;

            GameObject ButtonLeave = new GameObject("ButtonLeaveConfiguration");
            ButtonLeave.AddComponent<RectTransform>();
            ButtonLeave.transform.SetParent(_SystemConfigurationPanel.gameObject.transform, true);
            ButtonLeave.GetComponent<RectTransform>().sizeDelta = new Vector2(_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 15, _SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 15);
            ButtonLeave.GetComponent<RectTransform>().anchoredPosition = new Vector2(_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2,
                                                                                    _SystemConfigurationPanel.GetComponent<RectTransform>().rect.height / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2);
            ButtonLeave.AddComponent<LeavePanelScript>();
            Image y = ButtonLeave.AddComponent<Image>();
            y.color = Color.red;

            AddSystemConfigurationScriptObjectComponent();
        }
        else
        {
            Destroy(GameObject.Find("SystemConfigurationPanel"));
        }

    }

    private void AddSystemConfigurationScriptObjectComponent()
    {
        AddGameMusicConfig();
        AddGameLanguageConfig();
    }

    private void AddGameLanguageConfig()
    {
        GameObject GameLanguagesText = new GameObject("GameLanguages");
        GameLanguagesText.AddComponent<RectTransform>();
        GameLanguagesText.AddComponent<Text>();

        GameLanguagesText.transform.SetParent(_SystemConfigurationPanel.transform, true);

        if (_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "french" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "français")
        {
            GameLanguagesText.GetComponent<Text>().text = "Langue";
        }
        else if (_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "English" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "Anglais")
        {
            GameLanguagesText.GetComponent<Text>().text = "Language";
        }
        GameLanguagesText.GetComponent<RectTransform>().sizeDelta = new Vector2(_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 2, _SystemConfigurationPanel.GetComponent<RectTransform>().rect.height / 8);
        GameLanguagesText.GetComponent<RectTransform>().anchoredPosition = new Vector2((-_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 2) + (GameLanguagesText.GetComponent<RectTransform>().rect.width / 2), _SystemConfigurationPanel.GetComponent<RectTransform>().rect.height / 4);
        GameLanguagesText.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        GameLanguagesText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        GameLanguagesText.GetComponent<Text>().fontStyle = FontStyle.Bold;
        GameLanguagesText.GetComponent<Text>().fontSize = (int)(GameLanguagesText.GetComponent<RectTransform>().rect.height / 2);

        createDropDownGameObjectLanguages(GameLanguagesText);
    }

    private void createDropDownGameObjectLanguages(GameObject Parent)
    {
        GameObject GameLanguagesDropDown = new GameObject("GameLanguagesDropDown");
        GameLanguagesDropDown.AddComponent<RectTransform>();
        Image z = GameLanguagesDropDown.AddComponent<Image>();
        GameLanguagesDropDown.transform.SetParent(Parent.transform, true);
        GameLanguagesDropDown.GetComponent<RectTransform>().sizeDelta = new Vector2(Parent.GetComponent<RectTransform>().rect.width, Parent.GetComponent<RectTransform>().rect.height);
        GameLanguagesDropDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(Parent.GetComponent<RectTransform>().rect.width, 0);
        z.color = Color.white;

        GameObject GameLanguagesDropDownArrow = new GameObject("GameLanguagesDropDownArrow");
        GameLanguagesDropDownArrow.AddComponent<RectTransform>();
        GameLanguagesDropDownArrow.AddComponent<Image>();
        GameLanguagesDropDownArrow.transform.SetParent(GameLanguagesDropDown.transform, true);
        GameLanguagesDropDownArrow.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().DownArrow;
        GameLanguagesDropDownArrow.GetComponent<RectTransform>().sizeDelta = new Vector2((GameLanguagesDropDown.GetComponent<RectTransform>().rect.width / 4), GameLanguagesDropDown.GetComponent<RectTransform>().rect.height);
        GameLanguagesDropDownArrow.GetComponent<RectTransform>().anchoredPosition = new Vector2((GameLanguagesDropDown.GetComponent<RectTransform>().rect.width / 8) * 3, 0);

        GameObject GameLanguagesDropDownLabel = new GameObject("GameLanguagesDropDownLabel");
        GameLanguagesDropDownLabel.AddComponent<RectTransform>();
        GameLanguagesDropDownLabel.AddComponent<Button>();
        GameLanguagesDropDownLabel.transform.SetParent(GameLanguagesDropDown.transform, true);
        GameLanguagesDropDownLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((GameLanguagesDropDown.GetComponent<RectTransform>().rect.width ), GameLanguagesDropDown.GetComponent<RectTransform>().rect.height);
        GameLanguagesDropDownLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        GameLanguagesDropDownLabel.AddComponent<Text>();
        GameLanguagesDropDownLabel.GetComponent<Text>().text = _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages;
        GameLanguagesDropDownLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        GameLanguagesDropDownLabel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        GameLanguagesDropDownLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
        GameLanguagesDropDownLabel.GetComponent<Text>().fontSize = (int)(gameObject.GetComponent<RectTransform>().rect.height / 2);
        GameLanguagesDropDownLabel.GetComponent<Text>().color = Color.black;
        GameLanguagesDropDownLabel.GetComponent<Button>().onClick.AddListener(() => DropDownList(GameLanguagesDropDown));

        

    }

    private void DropDownList(GameObject parent)
    {
        if (GameObject.Find("GameLanguagesDropDownList") == false)
        {
            _userInterface.GetComponent<Monitoring>().CreateGameLanguagesList();
            List<string> GameLanguages = _userInterface.GetComponent<Monitoring>().GetGameLanguaguesList;
            int GameLanguagesCount = GameLanguages.Count;;

            GameObject GameLanguagesDropDownList = new GameObject("GameLanguagesDropDownList");
            GameLanguagesDropDownList.AddComponent<RectTransform>();
            Image z = GameLanguagesDropDownList.AddComponent<Image>();

            GameLanguagesDropDownList.transform.SetParent(parent.transform, true);

            GameLanguagesDropDownList.GetComponent<RectTransform>().sizeDelta = new Vector2(parent.GetComponent<RectTransform>().rect.width, parent.GetComponent<RectTransform>().rect.height * GameLanguagesCount);
            GameLanguagesDropDownList.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (-parent.GetComponent<RectTransform>().rect.height / 2) - (GameLanguagesDropDownList.GetComponent<RectTransform>().rect.height / 2));
            
            z.color = Color.white;

            GameLanguagesDropDownListItem(GameLanguagesDropDownList, GameLanguages, parent);
        }
        else
        {
            Destroy(GameObject.Find("GameLanguagesDropDownList"));
        }
    }

    private void GameLanguagesDropDownListItem(GameObject parent, List<string> LanguagesList, GameObject OlderParent)
    {
        for(int x = 0; x < LanguagesList.Count; x++)
        {
            GameObject gameObject = new GameObject(LanguagesList[x]);
            gameObject.AddComponent<RectTransform>();
            gameObject.AddComponent<Text>();
            gameObject.AddComponent<Button>();

            gameObject.transform.SetParent(OlderParent.transform, true);

            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(OlderParent.GetComponent<RectTransform>().rect.width, OlderParent.GetComponent<RectTransform>().rect.height);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(gameObject.GetComponent<RectTransform>().rect.height) * (x + 1));

            gameObject.GetComponent<Text>().text = LanguagesList[x];
            gameObject.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
            gameObject.GetComponent<Text>().fontSize = (int)(base.gameObject.GetComponent<RectTransform>().rect.height / 2);
            gameObject.GetComponent<Text>().color = Color.black;

            if(x == 0)
            {
                gameObject.GetComponent<Button>().onClick.AddListener(() => ChangesCurrentLanguages(LanguagesList, 0));
            }
            if(x == 1)
            {
                gameObject.GetComponent<Button>().onClick.AddListener(() => ChangesCurrentLanguages(LanguagesList, 1));
            }

            gameObject.transform.SetParent(parent.transform, true);
        }
    }

    private void ChangesCurrentLanguages(List<string> GameLanguages, int button)
    {
        _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages = GameLanguages[button];
        _userInterface.GetComponent<Monitoring>().CreateGameLanguagesList();
        GameObject.Find("GameLanguagesDropDownLabel").GetComponent<Text>().text = _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages;
        Destroy(GameObject.Find("GameLanguagesDropDownList"));
    }

    private void AddGameMusicConfig()
    {
        GameObject GameMusicText = new GameObject("GameMusicText");
        GameMusicText.AddComponent<RectTransform>();
        GameMusicText.AddComponent<Text>();

        GameMusicText.transform.SetParent(_SystemConfigurationPanel.transform, true);

        if (_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "french" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "français")
        {
            GameMusicText.GetComponent<Text>().text = "Musique";
        }
        else if (_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "English" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "Anglais")
        {
            GameMusicText.GetComponent<Text>().text = "Music";
        }
        GameMusicText.GetComponent<RectTransform>().sizeDelta = new Vector2(_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 2, _SystemConfigurationPanel.GetComponent<RectTransform>().rect.height / 8);
        GameMusicText.GetComponent<RectTransform>().anchoredPosition = new Vector2((-_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 2) + (GameMusicText.GetComponent<RectTransform>().rect.width / 2), 0);
        GameMusicText.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        GameMusicText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        GameMusicText.GetComponent<Text>().fontStyle = FontStyle.Bold;
        GameMusicText.GetComponent<Text>().fontSize = (int)(GameMusicText.GetComponent<RectTransform>().rect.height / 2);

        CreateMusiquelevelBackGround(GameMusicText);
        CreateSoundEffectLevelBackGround(GameMusicText);
    }

    private void CreateMusiquelevelBackGround(GameObject Parent)
    {
        GameObject CreateMusiquelevelBackGround = new GameObject("CreateMusiquelevelBackGround");
        CreateMusiquelevelBackGround.AddComponent<RectTransform>();
        CreateMusiquelevelBackGround.transform.SetParent(Parent.transform, true);
        CreateMusiquelevelBackGround.GetComponent<RectTransform>().sizeDelta = new Vector2(Parent.GetComponent<RectTransform>().rect.width, Parent.GetComponent<RectTransform>().rect.height);
        CreateMusiquelevelBackGround.GetComponent<RectTransform>().anchoredPosition = new Vector2(Parent.GetComponent<RectTransform>().rect.width, 0);

        CreateMusiquelevelLabel(CreateMusiquelevelBackGround);
        CreateMusicLevelNb(CreateMusiquelevelBackGround);
        CreateMusicLevelSlider(CreateMusiquelevelBackGround);
    }

    private void CreateMusiquelevelLabel(GameObject Parent)
    {
        GameObject CreateMusiquelevelLabel = new GameObject("CreateMusiquelevelLabel");
        CreateMusiquelevelLabel.AddComponent<RectTransform>();
        CreateMusiquelevelLabel.transform.SetParent(Parent.transform, true);
        CreateMusiquelevelLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((Parent.GetComponent<RectTransform>().rect.width), Parent.GetComponent<RectTransform>().rect.height);
        CreateMusiquelevelLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        CreateMusiquelevelLabel.AddComponent<Text>();
        if(_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "French" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "Français")
        {
            CreateMusiquelevelLabel.GetComponent<Text>().text = "Bande Sonore";
        }
        else if(_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "English" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "Anglais")
        {
            CreateMusiquelevelLabel.GetComponent<Text>().text = "Sound Track";
        }
        CreateMusiquelevelLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        CreateMusiquelevelLabel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
        CreateMusiquelevelLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
        CreateMusiquelevelLabel.GetComponent<Text>().fontSize = (int)(base.gameObject.GetComponent<RectTransform>().rect.height / 2);
        CreateMusiquelevelLabel.GetComponent<Text>().color = Color.black;
    }

    private void CreateMusicLevelNb(GameObject Parent)
    {
        GameObject CreateMusicLevelNb = new GameObject("CreateMusicLevelNb");
        CreateMusicLevelNb.AddComponent<RectTransform>();
        CreateMusicLevelNb.transform.SetParent(Parent.transform, true);
        CreateMusicLevelNb.GetComponent<RectTransform>().sizeDelta = new Vector2((Parent.GetComponent<RectTransform>().rect.width), Parent.GetComponent<RectTransform>().rect.height);
        CreateMusicLevelNb.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        CreateMusicLevelNb.AddComponent<Text>();
        CreateMusicLevelNb.GetComponent<Text>().text = 50.ToString();
        CreateMusicLevelNb.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        CreateMusicLevelNb.GetComponent<Text>().alignment = TextAnchor.LowerRight;
        CreateMusicLevelNb.GetComponent<Text>().fontStyle = FontStyle.Bold;
        CreateMusicLevelNb.GetComponent<Text>().fontSize = (int)(base.gameObject.GetComponent<RectTransform>().rect.height / 2);
        CreateMusicLevelNb.GetComponent<Text>().color = Color.black;
    }

    private void CreateMusicLevelSlider(GameObject Parent)
    {
        GameObject CreateMusicLevelSliderBackGround = new GameObject("CreateMusicLevelSliderBackGround");
        CreateMusicLevelSliderBackGround.AddComponent<RectTransform>();
        CreateMusicLevelSliderBackGround.transform.SetParent(Parent.transform, true);
        CreateMusicLevelSliderBackGround.GetComponent<RectTransform>().sizeDelta = new Vector2((Parent.GetComponent<RectTransform>().rect.width / 10) * 9, Parent.GetComponent<RectTransform>().rect.height / 6);
        CreateMusicLevelSliderBackGround.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -Parent.GetComponent<RectTransform>().rect.height / 3);
        CreateMusicLevelSliderBackGround.AddComponent<Image>();
        CreateMusicLevelSliderBackGround.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().GetKnob;

        GameObject CreateMusicLevelSliderBall = new GameObject("CreateMusicLevelSliderBall");
        CreateMusicLevelSliderBall.AddComponent<RectTransform>();
        CreateMusicLevelSliderBall.transform.SetParent(CreateMusicLevelSliderBackGround.transform, true);
        CreateMusicLevelSliderBall.GetComponent<RectTransform>().sizeDelta = new Vector2(CreateMusicLevelSliderBackGround.GetComponent<RectTransform>().rect.height * 1.5f, CreateMusicLevelSliderBackGround.GetComponent<RectTransform>().rect.height * 1.5f);
        CreateMusicLevelSliderBall.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        CreateMusicLevelSliderBall.AddComponent<Image>();
        CreateMusicLevelSliderBall.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().GetKnob;
        CreateMusicLevelSliderBackGround.AddComponent<SliderScriptSoundTrack>();
    }

    private void CreateSoundEffectLevelBackGround(GameObject Parent)
    {
        GameObject CreateSoundEffectLevelBackGround = new GameObject("CreateSoundEffectLevelBackGround");
        CreateSoundEffectLevelBackGround.AddComponent<RectTransform>();
        CreateSoundEffectLevelBackGround.transform.SetParent(Parent.transform, true);
        CreateSoundEffectLevelBackGround.GetComponent<RectTransform>().sizeDelta = new Vector2(Parent.GetComponent<RectTransform>().rect.width, Parent.GetComponent<RectTransform>().rect.height);
        CreateSoundEffectLevelBackGround.GetComponent<RectTransform>().anchoredPosition = new Vector2(Parent.GetComponent<RectTransform>().rect.width, -Parent.GetComponent<RectTransform>().rect.height);
        CreateSoundEffectlevelLabel(CreateSoundEffectLevelBackGround);
        CreateSoundEffectLevelNb(CreateSoundEffectLevelBackGround);
        CreateSoundEffectLevelSlider(CreateSoundEffectLevelBackGround);
    }

    private void CreateSoundEffectlevelLabel(GameObject Parent)
    {
        GameObject CreateSoundEffectlevelLabel = new GameObject("CreateSoundEffectlevelLabel");
        CreateSoundEffectlevelLabel.AddComponent<RectTransform>();
        CreateSoundEffectlevelLabel.transform.SetParent(Parent.transform, true);
        CreateSoundEffectlevelLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((Parent.GetComponent<RectTransform>().rect.width), Parent.GetComponent<RectTransform>().rect.height);
        CreateSoundEffectlevelLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        CreateSoundEffectlevelLabel.AddComponent<Text>();
        if (_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "French" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "Français")
        {
            CreateSoundEffectlevelLabel.GetComponent<Text>().text = "Effet Sonore";
        }
        else if (_userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "English" || _userInterface.GetComponent<Monitoring>().GetCurrentGameLanguages == "Anglais")
        {
            CreateSoundEffectlevelLabel.GetComponent<Text>().text = "Sound Effect";
        }
        CreateSoundEffectlevelLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        CreateSoundEffectlevelLabel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
        CreateSoundEffectlevelLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
        CreateSoundEffectlevelLabel.GetComponent<Text>().fontSize = (int)(base.gameObject.GetComponent<RectTransform>().rect.height / 2);
        CreateSoundEffectlevelLabel.GetComponent<Text>().color = Color.black;
    }

    private void CreateSoundEffectLevelSlider(GameObject Parent)
    {
        GameObject CreateSoundEffectLevelSliderBackGround = new GameObject("CreateSoundEffectLevelSliderBackGround");
        CreateSoundEffectLevelSliderBackGround.AddComponent<RectTransform>();
        CreateSoundEffectLevelSliderBackGround.transform.SetParent(Parent.transform, true);
        CreateSoundEffectLevelSliderBackGround.GetComponent<RectTransform>().sizeDelta = new Vector2((Parent.GetComponent<RectTransform>().rect.width / 10) * 9, Parent.GetComponent<RectTransform>().rect.height / 6);
        CreateSoundEffectLevelSliderBackGround.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -Parent.GetComponent<RectTransform>().rect.height / 3);
        CreateSoundEffectLevelSliderBackGround.AddComponent<Image>();
        CreateSoundEffectLevelSliderBackGround.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().GetKnob;

        GameObject CreateSoundEffectLevelSliderBall = new GameObject("CreateSoundEffectLevelSliderBall");
        CreateSoundEffectLevelSliderBall.AddComponent<RectTransform>();
        CreateSoundEffectLevelSliderBall.transform.SetParent(CreateSoundEffectLevelSliderBackGround.transform, true);
        CreateSoundEffectLevelSliderBall.GetComponent<RectTransform>().sizeDelta = new Vector2(CreateSoundEffectLevelSliderBackGround.GetComponent<RectTransform>().rect.height * 1.5f, CreateSoundEffectLevelSliderBackGround.GetComponent<RectTransform>().rect.height * 1.5f);
        CreateSoundEffectLevelSliderBall.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        CreateSoundEffectLevelSliderBall.AddComponent<Image>();
        CreateSoundEffectLevelSliderBall.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().GetKnob;
        CreateSoundEffectLevelSliderBackGround.AddComponent<SliderScriptSoundEffect>();
    }

    private void CreateSoundEffectLevelNb(GameObject Parent)
    {
        GameObject CreateSoundEffectLevelNb = new GameObject("CreateSoundEffectLevelNb");
        CreateSoundEffectLevelNb.AddComponent<RectTransform>();
        CreateSoundEffectLevelNb.transform.SetParent(Parent.transform, true);
        CreateSoundEffectLevelNb.GetComponent<RectTransform>().sizeDelta = new Vector2((Parent.GetComponent<RectTransform>().rect.width), Parent.GetComponent<RectTransform>().rect.height);
        CreateSoundEffectLevelNb.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        CreateSoundEffectLevelNb.AddComponent<Text>();
        CreateSoundEffectLevelNb.GetComponent<Text>().text = 50.ToString();
        CreateSoundEffectLevelNb.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        CreateSoundEffectLevelNb.GetComponent<Text>().alignment = TextAnchor.LowerRight;
        CreateSoundEffectLevelNb.GetComponent<Text>().fontStyle = FontStyle.Bold;
        CreateSoundEffectLevelNb.GetComponent<Text>().fontSize = (int)(base.gameObject.GetComponent<RectTransform>().rect.height / 2);
        CreateSoundEffectLevelNb.GetComponent<Text>().color = Color.black;
    }
}
