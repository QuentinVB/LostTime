using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SystemConfigurationScript : MonoBehaviour, IPointerDownHandler
{
    private bool _isSystemConfigPanelActivated;
    private bool _isSystemConfigAnimationOn;

    private void Update()
    {
        if(GameObject.Find("SystemConfigurationPanel") == true && _isSystemConfigPanelActivated == true && _isSystemConfigAnimationOn == true)
        {
            _isSystemConfigAnimationOn = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("SystemConfigurationPanel",
                0, 0, -1);
        }
        else if(GameObject.Find("SystemConfigurationPanel") == true && _isSystemConfigPanelActivated == false && _isSystemConfigAnimationOn == true)
        {
            _isSystemConfigAnimationOn = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("SystemConfigurationPanel",
                (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 2), 1);
        }
    }


    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("QuestBookPanel") == true)
            Destroy(GameObject.Find("QuestBookPanel"));

        if (GameObject.Find("GameMapPanel") == true)
            Destroy(GameObject.Find("GameMapPanel"));

        if (GameObject.Find("InventoryBag") == true)
            Destroy(GameObject.Find("InventoryBag"));

        if (GameObject.Find("SystemConfigurationPanel") == false)
        {
            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SystemConfigurationPanel", GameObject.Find("Canvas"), true, 
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height,
                0, (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height), 
                Color.grey);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SystemConfigurationPanelLabel", GameObject.Find("SystemConfigurationPanel"), true,
                GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width, GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height,
                0, 0, "Game Config", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter, FontStyle.Bold, 
                ((int)(GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 10)), Color.black);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("ButtonLeaveConfiguration", GameObject.Find("SystemConfigurationPanel"), true,
                GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 15,
                GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 15,
                GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 2 - GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 30,
                GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 30,
                Color.red);
            GameObject.Find("ButtonLeaveConfiguration").AddComponent<LeavePanelScript>();

            _isSystemConfigPanelActivated = true;
            _isSystemConfigAnimationOn = true;

            AddGameMusicConfig();
            AddGameLanguageConfig();
        }
        else
        {
            _isSystemConfigPanelActivated = false;
            _isSystemConfigAnimationOn = true;
        }
    }

    private void AddGameLanguageConfig()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("GameLanguagesText", GameObject.Find("SystemConfigurationPanel"), true,
            GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 2,
            GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 8,
            (GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / -2) + 
            (GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 4),
            GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 4,
            "Language", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            (int)(GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 16), Color.black);

        createDropDownGameObjectLanguages();
    }

    private void createDropDownGameObjectLanguages()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("GameLanguagesDropDown", GameObject.Find("GameLanguagesText"), true,
            GameObject.Find("GameLanguagesText").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameLanguagesText").GetComponent<RectTransform>().rect.height,
            GameObject.Find("GameLanguagesText").GetComponent<RectTransform>().rect.width, 0,
            Color.white);

        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("GameLanguagesDropDownArrow", GameObject.Find("GameLanguagesDropDown"), true,
            GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.width / 4,
            GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height,
            (GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.width / 8) * 3, 0,
            GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetDownArrow);

        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("GameLanguagesDropDownLabel", GameObject.Find("GameLanguagesDropDown"), true,
            GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height,
            0, 0, PlayerPrefs.GetString("CurrentLanguagesUsed"), GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont,
            TextAnchor.MiddleCenter, FontStyle.Bold, (int)(GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height / 2), Color.black);
        GameObject.Find("GameLanguagesDropDownLabel").AddComponent<Button>();
        GameObject.Find("GameLanguagesDropDownLabel").GetComponent<Button>().onClick.AddListener(() => DropDownList());
    }

    private void DropDownList()
    {
        if (GameObject.Find("GameLanguagesDropDownList") == false)
        {
            GameObject.Find("Canvas").GetComponent<Monitoring>().CreateGameLanguagesList();
            List<string> GameLanguages = GameObject.Find("Canvas").GetComponent<Monitoring>().GetGameLanguaguesList;
            int GameLanguagesCount = GameLanguages.Count;

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("GameLanguagesDropDownList", GameObject.Find("GameLanguagesDropDown"), true,
                GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.width,
                GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height * GameLanguagesCount,
                0, (GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height / -2) - (GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height * GameLanguagesCount) / 2,
                Color.white);
            GameLanguagesDropDownListItem(GameLanguages);
        }
        else
        {
            Destroy(GameObject.Find("GameLanguagesDropDownList"));
        }
    }

    private void GameLanguagesDropDownListItem(List<string> LanguagesList)
    {
        for(int x = 0; x < LanguagesList.Count; x++)
        {
            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(LanguagesList[x], GameObject.Find("GameLanguagesDropDown"), true,
                GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.width,
                GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height,
                0, GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height * -(x + 1),
                LanguagesList[x], GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter,
                FontStyle.Bold, (int)(GameObject.Find("GameLanguagesDropDown").GetComponent<RectTransform>().rect.height / 2), Color.black);

            if(x == 0)
            {
                GameObject.Find(LanguagesList[x]).AddComponent<Button>();
                GameObject.Find(LanguagesList[x]).GetComponent<Button>().onClick.AddListener(() => ChangesCurrentLanguages(LanguagesList, 0));
            }
            if(x == 1)
            {
                GameObject.Find(LanguagesList[x]).AddComponent<Button>();
                GameObject.Find(LanguagesList[x]).GetComponent<Button>().onClick.AddListener(() => ChangesCurrentLanguages(LanguagesList, 1));
            }

            GameObject.Find(LanguagesList[x]).transform.SetParent(GameObject.Find("GameLanguagesDropDownList").transform, true);
        }
    }

    private void ChangesCurrentLanguages(List<string> GameLanguages, int button)
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", GameLanguages[button]);
        GameObject.Find("Canvas").GetComponent<Monitoring>().CreateGameLanguagesList();
        GameObject.Find("GameLanguagesDropDownLabel").GetComponent<Text>().text = PlayerPrefs.GetString("CurrentLanguagesUsed");
        Destroy(GameObject.Find("GameLanguagesDropDownList"));
    }

    private void AddGameMusicConfig()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("GameMusicText", GameObject.Find("SystemConfigurationPanel"), true,
            GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 2,
            GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 8,
            (GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / -2) + GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.width / 4,
            0, "Music", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            (int)(GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 16), Color.black);

        CreateMusiquelevelBackGround();
        CreateSoundEffectLevelBackGround();
    }

    private void CreateMusiquelevelBackGround()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("CreateMusicLevelBackGround", GameObject.Find("GameMusicText"), true,
            GameObject.Find("GameMusicText").GetComponent<RectTransform>().rect.width, GameObject.Find("GameMusicText").GetComponent<RectTransform>().rect.height,
            GameObject.Find("GameMusicText").GetComponent<RectTransform>().rect.width, 0);

        CreateMusiquelevelLabel();
        CreateMusicLevelNb();
        CreateMusicLevelSlider();
    }

    private void CreateMusiquelevelLabel()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("CreateMusicLevelLabel", GameObject.Find("CreateMusicLevelBackGround"), true,
            GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.width,
            GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.height,
            0, 0, "Sound Track", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter,
            FontStyle.Bold, (int)(GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.height / 2), Color.black);
    }

    private void CreateMusicLevelNb()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("CreateMusicLevelNb", GameObject.Find("CreateMusicLevelBackGround"), true,
            GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.width,
            GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.height,
            0, 0, PlayerPrefs.GetString("SoundTrackVolumeSave"), GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.LowerRight,
            FontStyle.Bold, (int)(GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.height / 2), Color.black);
    }

    private void CreateMusicLevelSlider()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("CreateMusicLevelSliderBackGround", GameObject.Find("CreateMusicLevelBackGround"),
            true, (GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.width / 10) * 9,
            GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.height / 6,
            0, GameObject.Find("CreateMusicLevelBackGround").GetComponent<RectTransform>().rect.height / -3, Color.white);

        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("CreateMusicLevelSliderBall", GameObject.Find("CreateMusicLevelSliderBackGround"), true,
            GameObject.Find("CreateMusicLevelSliderBackGround").GetComponent<RectTransform>().rect.height * 3f,
            GameObject.Find("CreateMusicLevelSliderBackGround").GetComponent<RectTransform>().rect.height * 3f,
            0, 0, GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetKnob);
        GameObject.Find("CreateMusicLevelSliderBall").AddComponent<SliderScriptSoundTrack>();
    }

    private void CreateSoundEffectLevelBackGround()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("CreateSoundEffectLevelBackGround", GameObject.Find("GameMusicText"), true,
            GameObject.Find("GameMusicText").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameMusicText").GetComponent<RectTransform>().rect.height,
            GameObject.Find("GameMusicText").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameMusicText").GetComponent<RectTransform>().rect.height * -1);

        CreateSoundEffectlevelLabel();
        CreateSoundEffectLevelNb();
        CreateSoundEffectLevelSlider();
    }

    private void CreateSoundEffectlevelLabel()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("CreateSoundEffectLevelLabel", GameObject.Find("CreateSoundEffectLevelBackGround"), true,
            GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.width,
            GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.height,
            0, 0, "Sound Effect", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter,
            FontStyle.Bold, (int)(GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.height / 2), Color.black);
    }

    private void CreateSoundEffectLevelSlider()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("CreateSoundEffectLevelSliderBackGround", GameObject.Find("CreateSoundEffectLevelBackGround"), true,
            (GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.width / 10) * 9,
            GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.height / 6,
            0, GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.height / -3,
            Color.white);


        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("CreateSoundEffectLevelSliderBall", GameObject.Find("CreateSoundEffectLevelSliderBackGround"), true,
            GameObject.Find("CreateSoundEffectLevelSliderBackGround").GetComponent<RectTransform>().rect.height * 3f,
            GameObject.Find("CreateSoundEffectLevelSliderBackGround").GetComponent<RectTransform>().rect.height * 3f,
            0, 0, GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetKnob);
        GameObject.Find("CreateSoundEffectLevelSliderBall").AddComponent<SliderScriptSoundEffect>();
    }

    private void CreateSoundEffectLevelNb()
    {
        GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("CreateSoundEffectLevelNb", GameObject.Find("CreateSoundEffectLevelBackGround"), true,
            GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.width,
            GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.height,
            0, 0, PlayerPrefs.GetString("SoundEffectVolumeSave"), GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.LowerRight, FontStyle.Bold,
            (int)(GameObject.Find("CreateSoundEffectLevelBackGround").GetComponent<RectTransform>().rect.height / 2), Color.black);
    }
}
