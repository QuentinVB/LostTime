using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour
{

    public Image _gameTittle;
    public Image _backGroundMenuGame;
    public Image _backGroundMenu;

    public Button _newGame;
    public Button _loadGame;
    public Button _ConfigureGame;

    public Text _newGameText;
    public Text _loadGameText;
    public Text _ConfigureGameText;

    private GameObject _newGamePanel;
    private GameObject _loadGamePanel;
    private GameObject _configureGamePanel;

    private bool _isNewGamePanelCreated;
    private bool _isLoadGamePanelCreated;
    private bool _isConfigureGamePanelCreated;

    private void Start()
    {
        _gameTittle.rectTransform.sizeDelta = new Vector2(Screen.width / 3, Screen.height / 3);
        _gameTittle.rectTransform.anchoredPosition = new Vector2((-Screen.width / 2) + (_gameTittle.rectTransform.rect.width / 2.5f), Screen.height / 4);

        _newGame.transform.SetParent(_gameTittle.transform, true);
        _newGame.GetComponent<RectTransform>().sizeDelta = new Vector2(_gameTittle.GetComponent<RectTransform>().rect.width, _gameTittle.GetComponent<RectTransform>().rect.height / 4);
        _newGame.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -_gameTittle.GetComponent<RectTransform>().rect.height / 2);
        _newGameText.fontSize = ((int)(_newGame.GetComponent<RectTransform>().rect.height - 10));

        _loadGame.transform.SetParent(_newGame.transform, true);
        _loadGame.GetComponent<RectTransform>().sizeDelta = new Vector2(_gameTittle.GetComponent<RectTransform>().rect.width, _gameTittle.GetComponent<RectTransform>().rect.height / 4);
        _loadGame.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -_gameTittle.GetComponent<RectTransform>().rect.height / 2);
        _loadGameText.fontSize = ((int)(_newGame.GetComponent<RectTransform>().rect.height - 10));

        _ConfigureGame.transform.SetParent(_loadGame.transform, true);
        _ConfigureGame.GetComponent<RectTransform>().sizeDelta = new Vector2(_gameTittle.GetComponent<RectTransform>().rect.width, _gameTittle.GetComponent<RectTransform>().rect.height / 4);
        _ConfigureGame.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -_gameTittle.GetComponent<RectTransform>().rect.height / 2);
        _ConfigureGameText.fontSize = ((int)(_newGame.GetComponent<RectTransform>().rect.height - 10));

        _backGroundMenuGame.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.height);

        _backGroundMenu.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    public void NewGame()
    {
        if (_isLoadGamePanelCreated == true)
        {
            Destroy(_loadGamePanel);
            _isLoadGamePanelCreated = false;
        }
        if (_isConfigureGamePanelCreated == true)
        {
            Destroy(_configureGamePanel);
            _isConfigureGamePanelCreated = false;
        }
        
        if (_isNewGamePanelCreated == false)
        {
            _newGamePanel = new GameObject("NewGamePanel");
            _newGamePanel.AddComponent<RectTransform>();
            _newGamePanel.transform.SetParent(_backGroundMenu.transform, true);
            _newGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_backGroundMenu.GetComponent<RectTransform>().rect.width / 4, 
                                                                                _backGroundMenu.GetComponent<RectTransform>().rect.height);
            _newGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(_backGroundMenu.GetComponent<RectTransform>().rect.width / 2.7f, 0);
            _isNewGamePanelCreated = true;

            CreateNewGamePanelComponent();
        }
        else
        {
            Destroy(_newGamePanel);
            _isNewGamePanelCreated = false;
        }
    }

    public void loadGame()
    {
        if (_isConfigureGamePanelCreated == true)
        {
            Destroy(_configureGamePanel);
            _isConfigureGamePanelCreated = false;
        }
        if (_isNewGamePanelCreated == true)
        {
            Destroy(_newGamePanel);
            _isNewGamePanelCreated = false;
        }

        if (_isLoadGamePanelCreated == false)
        {
            _loadGamePanel = new GameObject("LoadGame");
            _loadGamePanel.AddComponent<RectTransform>();
            _loadGamePanel.transform.SetParent(_backGroundMenu.transform, true);
            _loadGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_backGroundMenu.GetComponent<RectTransform>().rect.width / 4, 
                                                                                    _backGroundMenu.GetComponent<RectTransform>().rect.height);
            _loadGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(_backGroundMenu.GetComponent<RectTransform>().rect.width / 2.7f, 0);
            _isLoadGamePanelCreated = true;

            CreateLoadGamePanelComponent();
        }
        else
        {
            Destroy(_loadGamePanel);
            _isLoadGamePanelCreated = false;
        }
    }

    public void ConfigureGame()
    {
        if (_isLoadGamePanelCreated == true)
        {
            Destroy(_loadGamePanel);
            _isLoadGamePanelCreated = false;
        }
        if (_isNewGamePanelCreated == true)
        {
            Destroy(_newGamePanel);
            _isNewGamePanelCreated = false;
        }

        if (_isConfigureGamePanelCreated == false)
        {

            _configureGamePanel = new GameObject("ConfigureGamePanel");
            _configureGamePanel.AddComponent<RectTransform>();
            Image ConfigureGamePanelImage = _configureGamePanel.AddComponent<Image>();
            ConfigureGamePanelImage.color = Color.green;
            _configureGamePanel.transform.SetParent(_backGroundMenu.transform, true);
            _configureGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_backGroundMenu.GetComponent<RectTransform>().rect.width / 4, _backGroundMenu.GetComponent<RectTransform>().rect.height);
            _configureGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(_backGroundMenu.GetComponent<RectTransform>().rect.width / 2.7f, 0);
            _isConfigureGamePanelCreated = true;
        }
        else
        {
            Destroy(_configureGamePanel);
            _isConfigureGamePanelCreated = false;
        }
    }
    

    private void CreateNewGamePanelComponent()
    {
        CreateGameObjectButtonMenuSystem("SaveState01", "SaveState01", _newGamePanel, true, _newGamePanel.GetComponent<RectTransform>().rect.width,
            (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f,
            Color.blue, true);
        CreateGameObjectButtonMenuSystem("SaveState02", "SaveState02", _newGamePanel, true, _newGamePanel.GetComponent<RectTransform>().rect.width,
            (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 0,
            Color.blue, true);
        CreateGameObjectButtonMenuSystem("SaveState03", "SaveState03", _newGamePanel, true, _newGamePanel.GetComponent<RectTransform>().rect.width,
            (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, -(_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f,
            Color.blue, true);
        CreateConfigureGamePanelComponent();
    }

    private void CreateLoadGamePanelComponent()
    {
        CreateGameObjectButtonMenuSystem("SaveState01", "SaveState01", _loadGamePanel, true, _loadGamePanel.GetComponent<RectTransform>().rect.width, 
            (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f,
            Color.blue, true);
        CreateGameObjectButtonMenuSystem("SaveState02", "SaveState02", _loadGamePanel, true, _loadGamePanel.GetComponent<RectTransform>().rect.width, 
            (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 0, 
            Color.blue, true);
        CreateGameObjectButtonMenuSystem("SaveState03", "SaveState03", _loadGamePanel, true, _loadGamePanel.GetComponent<RectTransform>().rect.width,
            (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, -(_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f,
            Color.blue, true);
    }

    private void CreateConfigureGamePanelComponent()
    {
        
    }

    private void CreateGameObjectButtonMenuSystem(string _gameObjectName, string gameObjectName, GameObject setParent, bool anchoredChildToParent, float sizeDeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY, Color color, bool isButton)
    {
        GameObject gameObject = new GameObject(gameObjectName);
        gameObject.AddComponent<RectTransform>();
        gameObject.transform.SetParent(setParent.transform, anchoredChildToParent);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDeltaX, sizeDeltaY);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);
        if (isButton == true)
        {
            
            // ajouter un script a chaque button pour valider son choix
        }
        Image x = gameObject.AddComponent<Image>();
        x.color = color;
    }

    public void test()
    {
        Application.Quit();
    }
}
