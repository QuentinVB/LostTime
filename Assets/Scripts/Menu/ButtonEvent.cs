using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour
{
    private GameObject _newGamePanel;
    private GameObject _loadGamePanel;
    private GameObject _configureGamePanel;

    private bool _newGamePanelActivated;
    private bool _newGameAnimationOn;

    private bool _loadGamePanelActivated;
    private bool _loadGameAnimationOn;

    private bool _configGamePanelActivated;
    private bool _configGameAnimationOn;

    private bool _choice;
    private bool _butonchoiceclicked;

    public Sprite _red;
    public Sprite _blue;
    public Sprite _yellow;

    private bool _isLoadPanelActivated;
    private void Start()
    {

        GameObject.Find("cloudLayer4").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer3").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer3.5").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer2").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer1").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);

        GameObject.Find("GameTittle").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, Screen.height / 3);
        GameObject.Find("GameTittle").GetComponent<RectTransform>().anchoredPosition = new Vector2((-Screen.width / 2) + GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width / 2.5f,
            Screen.height / 4);


        GameObject.Find("ButtonNewGame").transform.SetParent(GameObject.Find("GameTittle").transform, true);
        GameObject.Find("ButtonNewGame").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 4);
        GameObject.Find("ButtonNewGame").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / -2);
        GameObject.Find("ButtonNewGameText").GetComponent<Text>().fontSize = ((int)(GameObject.Find("ButtonNewGame").GetComponent<RectTransform>().rect.height - 10));
        GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages("ButtonNewGameText", "New Game", "Nouvelle Partie");

        GameObject.Find("ButtonLoadSave").transform.SetParent(GameObject.Find("ButtonNewGame").transform, true);
        GameObject.Find("ButtonLoadSave").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 4);
        GameObject.Find("ButtonLoadSave").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 2);
        GameObject.Find("ButtonLoadSaveText").GetComponent<Text>().fontSize = ((int)(GameObject.Find("ButtonLoadSave").GetComponent<RectTransform>().rect.height - 15));
        GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages("ButtonLoadSaveText", "Load Game", "Charger une Partie");

        //GameObject.Find("ButtonConfigure").transform.SetParent(GameObject.Find("ButtonLoadSave").transform, true);
        //GameObject.Find("ButtonConfigure").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width,
        //    GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 4);
        //GameObject.Find("ButtonConfigure").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 2);
        //GameObject.Find("ButtonConfigureText").GetComponent<Text>().fontSize = ((int)(GameObject.Find("ButtonConfigure").GetComponent<RectTransform>().rect.height - 10));


        GameObject.Find("BackGroundMenu").transform.SetParent(GameObject.Find("MenuGameUserInterface").transform, true);
        GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().sizeDelta = GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().sizeDelta;
        GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);


        GameObject.Find("BackGroundMenuGame").transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
        GameObject.Find("BackGroundMenuGame").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height, Screen.height);
        GameObject.Find("BackGroundMenuGame").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        GameObject.Find("EventSystem").AddComponent<SoundController>();
        GameObject.Find("EventSystem").GetComponent<SoundController>().PlaySong(((AudioClip)(Resources.Load("Sound/Cloud Atlas - 02 - Cloud Atlas Opening Title"))), 2f, true);
        GameObject.Find("EventSystem").GetComponent<SoundController>().GetSongOnOff = true;

        if(PlayerPrefs.HasKey("CurrentLanguagesUsed") == false)
        {
            SceneManager.LoadScene("LostTimeGameLanguagesFirstChoice");
        }
    }

    private void Update()
    {
        if (GameObject.Find("NewGamePanel") == true)
        {
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateOneYellowGearSprite", 0, 0, 0, 0, -1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateOneRedGearSprite", 0, 0, 0, 0, 1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateOneBlueGearSprite", 0, 0, 0, 0, -1, 2);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateTwoYellowGearSprite", 0, 0, 0, 0, -1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateTwoRedGearSprite", 0, 0, 0, 0, 1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateTwoBlueGearSprite", 0, 0, 0, 0, -1, 2);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateThreeYellowGearSprite", 0, 0, 0, 0, -1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateThreeRedGearSprite", 0, 0, 0, 0, 1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateThreeBlueGearSprite", 0, 0, 0, 0, -1, 2);
        }

        if (GameObject.Find("LoadGamePanel") == true)
        {
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateOneYellowGearSprite", 0, 0, 0, 0, -1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateOneRedGearSprite", 0, 0, 0, 0, 1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateOneBlueGearSprite", 0, 0, 0, 0, -1, 2);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateTwoYellowGearSprite", 0, 0, 0, 0, -1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateTwoRedGearSprite", 0, 0, 0, 0, 1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateTwoBlueGearSprite", 0, 0, 0, 0, -1, 2);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateThreeYellowGearSprite", 0, 0, 0, 0, -1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateThreeRedGearSprite", 0, 0, 0, 0, 1, 2);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateThreeBlueGearSprite", 0, 0, 0, 0, -1, 2);
        }

        if (GameObject.Find("NewGamePanel") == true && _newGamePanelActivated == true && _newGameAnimationOn == true)
        {
            _newGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("NewGamePanel",
                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("NewGamePanel") == true && _newGamePanelActivated == false && _newGameAnimationOn == true)
        {
            Destroy(GameObject.Find("PanelOverWriteData"));
            _newGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("NewGamePanel",
                GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("NewGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }

        if (GameObject.Find("LoadGamePanel") == true && _loadGamePanelActivated == true && _loadGameAnimationOn == true)
        {
            _loadGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("LoadGamePanel",
                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("LoadGamePanel") == true && _loadGamePanelActivated == false && _loadGameAnimationOn == true)
        {
            Destroy(GameObject.Find("PanelSaveStateEmpty"));
            _loadGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("LoadGamePanel",
                GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("LoadGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }

        if (GameObject.Find("ConfigureGamePanel") == true && _configGamePanelActivated == true && _configGameAnimationOn == true)
        {
            _configGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("ConfigureGamePanel",
                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("ConfigureGamePanel") == true && _configGamePanelActivated == false && _configGameAnimationOn == true)
        {
            _configGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("ConfigureGamePanel",
                GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("ConfigureGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }




    }

    private void checkOpenPanel()
    {
        if (GameObject.Find("NewGamePanel") == true)
        {
            _newGamePanelActivated = false;
            _newGameAnimationOn = true;
        }

        if (GameObject.Find("LoadGamePanel") == true)
        {
            _loadGameAnimationOn = true;
            _loadGamePanelActivated = false;
        }

        if (GameObject.Find("ConfigureGamePanel") == true)
        {
            _configGamePanelActivated = false;
            _configGameAnimationOn = true;
        }
    }

    public void NewGame()
    {
        checkOpenPanel();
        _isLoadPanelActivated = false;

        if (GameObject.Find("NewGamePanel") == false)
        {
            GameObject.Find("EventSystem").GetComponent<SoundController>().GetSongOnOff = false;

            _newGamePanel = new GameObject("NewGamePanel");
            _newGamePanel.AddComponent<RectTransform>();
            _newGamePanel.transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
            _newGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 4,
                                                                                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.height);
            _newGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("NewGamePanel").GetComponent<RectTransform>().rect.width / 2, 0);


            CreateNewGamePanelCSaveStateComponent("SaveStateOne", "SaveStateOne", "NewGamePanel", _newGamePanel.GetComponent<RectTransform>().rect.width,
                (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f);
            GameObject.Find("SaveStateOneButtonZone").AddComponent<Button>();
            GameObject.Find("SaveStateOneButtonZone").GetComponent<Button>().onClick.AddListener(() => SaveStateAction("SaveStateOne"));


            CreateNewGamePanelCSaveStateComponent("SaveStateTwo", "SaveStateTwo", "NewGamePanel", _newGamePanel.GetComponent<RectTransform>().rect.width,
                (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, 0);
            GameObject.Find("SaveStateTwoButtonZone").AddComponent<Button>();
            GameObject.Find("SaveStateTwoButtonZone").GetComponent<Button>().onClick.AddListener(() => SaveStateAction("SaveStateTwo"));


            CreateNewGamePanelCSaveStateComponent("SaveStateThree", "SaveStateThree", "NewGamePanel", _newGamePanel.GetComponent<RectTransform>().rect.width,
                (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * -3.5f);
            GameObject.Find("SaveStateThreeButtonZone").AddComponent<Button>();
            GameObject.Find("SaveStateThreeButtonZone").GetComponent<Button>().onClick.AddListener(() => SaveStateAction("SaveStateThree"));


            _newGamePanelActivated = true;
            _newGameAnimationOn = true;
        }
        else
        {
            _newGamePanelActivated = false;
            _newGameAnimationOn = true;
        }
    }

    public void loadGame()
    {
        checkOpenPanel();
        _isLoadPanelActivated = true;

        if (GameObject.Find("LoadGamePanel") == false)
        {
            _loadGamePanel = new GameObject("LoadGamePanel");
            _loadGamePanel.AddComponent<RectTransform>();
            _loadGamePanel.transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
            _loadGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 4,
                                                                                    GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.height);
            _loadGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("LoadGamePanel").GetComponent<RectTransform>().rect.width / 2, 0);

            CreateNewGamePanelCSaveStateComponent("LoadSaveStateOne", "SaveStateOne", "LoadGamePanel", _loadGamePanel.GetComponent<RectTransform>().rect.width,
                (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f);
            GameObject.Find("LoadSaveStateOneButtonZone").AddComponent<Button>();
            GameObject.Find("LoadSaveStateOneButtonZone").GetComponent<Button>().onClick.AddListener(() => LoadStateAction("SaveStateOne"));


            CreateNewGamePanelCSaveStateComponent("LoadSaveStateTwo", "SaveStateTwo", "LoadGamePanel", _loadGamePanel.GetComponent<RectTransform>().rect.width,
                (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, 0);
            GameObject.Find("LoadSaveStateTwoButtonZone").AddComponent<Button>();
            GameObject.Find("LoadSaveStateTwoButtonZone").GetComponent<Button>().onClick.AddListener(() => LoadStateAction("SaveStateTwo"));


            CreateNewGamePanelCSaveStateComponent("LoadSaveStateThree", "SaveStateThree", "LoadGamePanel", _loadGamePanel.GetComponent<RectTransform>().rect.width,
                (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * -3.5f);
            GameObject.Find("LoadSaveStateThreeButtonZone").AddComponent<Button>();
            GameObject.Find("LoadSaveStateThreeButtonZone").GetComponent<Button>().onClick.AddListener(() => LoadStateAction("SaveStateThree"));


            _loadGamePanelActivated = true;
            _loadGameAnimationOn = true;
        }
        else
        {
            _loadGamePanelActivated = false;
            _loadGameAnimationOn = true;
        }
    }

    public void ConfigureGame()
    {
        checkOpenPanel();

        if (GameObject.Find("ConfigureGamePanel") == false)
        {

            _configureGamePanel = new GameObject("ConfigureGamePanel");
            _configureGamePanel.AddComponent<RectTransform>();
            Image ConfigureGamePanelImage = _configureGamePanel.AddComponent<Image>();
            ConfigureGamePanelImage.color = Color.green;
            _configureGamePanel.transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
            _configureGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 4, GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.height);
            _configureGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("ConfigureGamePanel").GetComponent<RectTransform>().rect.width / 2, 0);

            _configGamePanelActivated = true;
            _configGameAnimationOn = true;
        }
        else
        {
            _configGamePanelActivated = false;
            _configGameAnimationOn = true;
        }

    }



    private void CreateNewGamePanelCSaveStateComponent(string GameObjectName, string PlayerPrefsCurrentSaveState, string GameObjectParentName, float sizedeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY)
    {
        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(GameObjectName, GameObject.Find(GameObjectParentName), true,
            sizedeltaX, sizeDeltaY, anchoredPositionX, anchoredPositionY, Color.clear);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "YellowGearSprite", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 3, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 3,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / -6, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / -4,
            _yellow);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "RedGearSprite", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / -3, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 6,
            _red);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "BlueGearSprite", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 5, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 5,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / -7, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 3,
            _blue);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(GameObjectName + "CycleTextZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 2, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 2,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 4, "",
            GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 10)), Color.black);
        if (PlayerPrefs.GetInt("Is" + PlayerPrefsCurrentSaveState + "Used") != 1)
        {
            GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages(GameObjectName + "CycleTextZone", "Empty Save", "Sauvegarde Vide");
        }
        else
        {
            GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages(GameObjectName + "CycleTextZone", "Number of cycle : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Cycle"), "Nombre de cycle : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Cycle"));
        }

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(GameObjectName + "FragmentTextZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 2, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 2,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / -4, "",
            GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 10)), Color.black);
        if (PlayerPrefs.GetInt("Is" + PlayerPrefsCurrentSaveState + "Used") != 1)
        {
            if (_isLoadPanelActivated == false)
            {
                GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages((GameObjectName + "FragmentTextZone"), "Start New Game", "Nouvelle Partie");
            }
        }
        else
        {
            GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages((GameObjectName + "FragmentTextZone"), "Number of fragments : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Fragments"), "Nombre de fragments : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Fragments"));
        }

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject(GameObjectName + "ButtonZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height, 0, 0);
        GameObject.Find(GameObjectName + "ButtonZone").AddComponent<Image>();
        GameObject.Find(GameObjectName + "ButtonZone").GetComponent<Image>().color = Color.clear;
    }


    public void SaveStateAction(string SaveStateName)
    {

        if (PlayerPrefs.GetInt("Is" + SaveStateName + "Used") == 1)
        {
            OverWriteDataFile(SaveStateName);
        }
        else
        {
            PlayerPrefs.SetInt("Is" + SaveStateName + "Used", 1);
            PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
            GameObject.Find("MenuGameUserInterface").GetComponent<SaveController>().InitialisePlayerSaveState();
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString(SaveStateName + "LastScene"));
            SceneManager.LoadScene(PlayerPrefs.GetString(SaveStateName + "LastScene"));
        }
    }

    private void LoadStateAction(string SaveStateName)
    {
        if (PlayerPrefs.GetInt("Is" + SaveStateName + "Used") == 1)
        {
            PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString(SaveStateName + "LastScene"));
            GameObject.Find("MenuGameUserInterface").GetComponent<SaveController>().LoadGame();
            SceneManager.LoadScene(PlayerPrefs.GetString(SaveStateName + "LastScene"));
        }
        else
        {
            LoadGame();
        }

    }

    public void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs have been reset");
        PlayerPrefs.SetString("SoundEffectVolumeSave", "50");
        PlayerPrefs.SetString("SoundTrackVolumeSave", "50");
        PlayerPrefs.SetInt("ShadowIsActivatedSave", 1);
        
        SceneManager.LoadScene("LostTimeMenuGame");
    }

    private void OverWriteDataFile(string SaveStateName)
    {

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("PanelOverWriteData", GameObject.Find("MenuGameUserInterface"), true,
            GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 4, GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.height / 2,
            0, 0, GameObject.Find("MenuGameUserInterface").GetComponent<ImageMonitoring>().GetBackGround5);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabel", GameObject.Find("PanelOverWriteData"), true,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3, 0,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6,
            "", GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages(("PanelOverWriteDataLabel"), "OverWrite Data File", "Ecraser les données");

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelYes", GameObject.Find("PanelOverWriteData"), true,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3,
            -GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
            -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6),
            "", GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages(("PanelOverWriteDataLabelYes"), "YES", "OUI");
        GameObject.Find("PanelOverWriteDataLabelYes").AddComponent<Button>();
        GameObject.Find("PanelOverWriteDataLabelYes").GetComponent<Button>().onClick.AddListener(() => Yes(SaveStateName));

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelNo", GameObject.Find("PanelOverWriteData"), true,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
            -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6),
            "", GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages(("PanelOverWriteDataLabelNo"), "NO", "NON");
        GameObject.Find("PanelOverWriteDataLabelNo").AddComponent<Button>();
        GameObject.Find("PanelOverWriteDataLabelNo").GetComponent<Button>().onClick.AddListener(() => No());
    }

    private void LoadGame()
    {
        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("PanelSaveStateEmpty", GameObject.Find("MenuGameUserInterface"), true,
            GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 4, GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.height / 2,
            0, 0, GameObject.Find("MenuGameUserInterface").GetComponent<ImageMonitoring>().GetBackGround5);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelSaveStateEmptyLabel", GameObject.Find("PanelSaveStateEmpty"), true,
            GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 3, 0,
            GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 6,
            "", GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages(("PanelSaveStateEmptyLabel"), "Empty SaveState", "Sauvegarde Vide");

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelSaveStateEmptyLabelYes", GameObject.Find("PanelSaveStateEmpty"), true,
            GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 3,
            0, -(GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 6),
            "", GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().setTextInCorrectLanguages(("PanelSaveStateEmptyLabelYes"), "OK", "OK");
        GameObject.Find("PanelSaveStateEmptyLabelYes").AddComponent<Button>();
        GameObject.Find("PanelSaveStateEmptyLabelYes").GetComponent<Button>().onClick.AddListener(() => ok());
    }

    private void Yes(string SaveStateName)
    {
        Destroy(GameObject.Find("PanelOverWriteData"));

        PlayerPrefs.SetInt("Is" + SaveStateName + "Used", 1);
        PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
        GameObject.Find("MenuGameUserInterface").GetComponent<SaveController>().InitialisePlayerSaveState();
        PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString(SaveStateName + "LastScene"));
        SceneManager.LoadScene(PlayerPrefs.GetString(SaveStateName + "LastScene"));
    }

    private void No()
    {
        Destroy(GameObject.Find("PanelOverWriteData"));
    }

    private void ok()
    {
        Destroy(GameObject.Find("PanelSaveStateEmpty"));
    }


}
