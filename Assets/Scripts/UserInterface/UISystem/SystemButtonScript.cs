using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SystemButtonScript : MonoBehaviour {

    private GameObject _userInterface;

    public Button _systemButton;
    public Button _inventoryButton;

    private bool _isPanelCreated;
    private bool _isInventoryCreated;

    private GameObject _systemPanel;
    private GameObject _inventoryBag;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas"); 
        _systemButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _inventoryButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _userInterface.AddComponent<Monitoring>();
    }

    public void CreateSystemPanel()
    {
        if (_isPanelCreated == false)
        {
            _systemPanel = new GameObject("SystemPanel");
            _systemPanel.AddComponent<RectTransform>();
            Image i = _systemPanel.AddComponent<Image>();
            i.color = Color.grey;
            _systemPanel.transform.SetParent(_userInterface.transform, true);
            _systemPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 8, (Screen.height / 4) * 3);
            _systemPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(Screen.width / 2) + (_systemPanel.GetComponent<RectTransform>().rect.width / 2), 
                                                                                    (- _systemButton.GetComponent<RectTransform>().rect.height / 2));

            CreateGameObjectButtonSystem("GameMap", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, _systemPanel.GetComponent<RectTransform>().rect.height / 3, Color.black, true);
            CreateGameObjectButtonSystem("QuestBook", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, _systemPanel.GetComponent<RectTransform>().rect.height / 8, Color.black, true);
            CreateGameObjectButtonSystem("SystemConfiguration", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, -_systemPanel.GetComponent<RectTransform>().rect.height / 8, Color.black, true);
            CreateGameObjectButtonSystem("Leave", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, -_systemPanel.GetComponent<RectTransform>().rect.height / 3, Color.black, true);

            _isPanelCreated = true;
        }
        else
        {
            Destroy(_systemPanel);
            _isPanelCreated = false;
        }
    }

    private void CreateGameObjectButtonSystem(string gameObjectName, GameObject setParent, bool anchoredChildToParent, float sizeDeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY, Color color, bool isButton)
    {
        GameObject gameObject = new GameObject(gameObjectName);
        gameObject.AddComponent<RectTransform>();
        gameObject.transform.SetParent(setParent.transform, anchoredChildToParent);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDeltaX, sizeDeltaY);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);
        if (isButton == true)
        {
            if (gameObjectName == "GameMap")
            {
                gameObject.AddComponent<GameMapScript>();
                gameObject.AddComponent<Image>();
                gameObject.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().MapButton;
            }

            if (gameObjectName == "QuestBook")
            {
                gameObject.AddComponent<QuestBookScript>();
                gameObject.AddComponent<Image>();
                gameObject.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().QuestButton;
            }

            if (gameObjectName == "SystemConfiguration")
            {
                gameObject.AddComponent<SystemConfigurationScript>();
                gameObject.AddComponent<Image>();
                gameObject.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().ConfigButton;
            }

            if (gameObjectName == "Leave")
            {
                gameObject.AddComponent<LeaveScript>();
                gameObject.AddComponent<Image>();
                gameObject.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().LeaveButton;
            }
        }
    }

    public void Inventaire()
    {
        if (_isInventoryCreated == false)
        {
            _isInventoryCreated = true;
            _inventoryBag = new GameObject("Inventory Bag");
            _inventoryBag.AddComponent<RectTransform>();
            _inventoryBag.transform.SetParent(_userInterface.gameObject.transform, true);
            _inventoryBag.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 2);
            _inventoryBag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            Image x = _inventoryBag.AddComponent<Image>();
            x.color = Color.grey;
            ShowInventoryObject();

        }
        else
        {
            Destroy(_inventoryBag);
            _isInventoryCreated = false;
        }
    }

    private void ShowInventoryObject()
    {
        int tmpCount = 1;

        for (int var = 0; var < tmpCount; var++)
        {
            CreateGameObjectButtonSystem("Hammer", _inventoryBag, true, (_inventoryBag.GetComponent<RectTransform>().rect.width / 10) / 2, (_inventoryBag.GetComponent<RectTransform>().rect.width / 10) / 2, (_inventoryBag.GetComponent<RectTransform>().rect.width / 10), (_inventoryBag.GetComponent<RectTransform>().rect.width / 10), Color.blue, false);
        }

    }
}
