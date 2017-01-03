using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SystemButtonScript : MonoBehaviour {

    public Canvas UserInterface;
    public Button _systemButton;
    public Button _inventoryButton;

    public bool _isPanelCreated;
    public bool _isInventoryCreated;
    private GameObject _systemPanel;
    private GameObject _inventoryBag;

    private void Start()
    {
        _systemButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _inventoryButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
    }

    public void CreateSystemPanel()
    {
        if (_isPanelCreated == false)
        {
            _systemPanel = new GameObject("Panel System");
            _systemPanel.AddComponent<RectTransform>();
            Image i = _systemPanel.AddComponent<Image>();
            i.color = Color.grey;
            _systemPanel.transform.SetParent(UserInterface.transform, true);
            _systemPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 8, (Screen.height / 4) * 3);
            _systemPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(Screen.width / 2) + (_systemPanel.GetComponent<RectTransform>().rect.width / 2), 
                                                                                    (- _systemButton.GetComponent<RectTransform>().rect.height / 2));
            



            CreateGameObjectButtonSystem("_map", "GameMap", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, _systemPanel.GetComponent<RectTransform>().rect.height / 3, Color.black, true);
            CreateGameObjectButtonSystem("_questBook", "QuestBook", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, _systemPanel.GetComponent<RectTransform>().rect.height / 8, Color.black, true);
            CreateGameObjectButtonSystem("_systemConfiguration", "System Configuration", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, -_systemPanel.GetComponent<RectTransform>().rect.height / 8, Color.black, true);
            CreateGameObjectButtonSystem("_leave", "Leave", _systemPanel, true, _systemPanel.GetComponent<RectTransform>().rect.width / 1.5f, _systemPanel.GetComponent<RectTransform>().rect.height / 8, 0, -_systemPanel.GetComponent<RectTransform>().rect.height / 3, Color.black, true);

            _isPanelCreated = true;
        }
        else
        {
            Destroy(_systemPanel);
            _isPanelCreated = false;
        }
    }

    private void CreateGameObjectButtonSystem(string GameObjectName, string gameObjectName, GameObject setParent, bool anchoredChildToParent, float sizeDeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY, Color color, bool isButton)
    {
        GameObject gameObject = new GameObject(gameObjectName);
        gameObject.AddComponent<RectTransform>();
        gameObject.transform.SetParent(setParent.transform, anchoredChildToParent);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDeltaX, sizeDeltaY);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);
        if (isButton == true)
        {
            gameObject.AddComponent<Button>();
            //gameObject.GetComponent<Button>().onClick.AddListener(Map);
        }
        Image x = gameObject.AddComponent<Image>();
        x.color = color;
    }

    public void Inventaire()
    {
        if (_isInventoryCreated == false)
        {
            _isInventoryCreated = true;
            _inventoryBag = new GameObject("Inventory Bag");
            _inventoryBag.AddComponent<RectTransform>();
            _inventoryBag.transform.SetParent(UserInterface.gameObject.transform, true);
            _inventoryBag.GetComponent<RectTransform>().sizeDelta = new Vector2(UserInterface.GetComponent<RectTransform>().rect.width / 2, UserInterface.GetComponent<RectTransform>().rect.height / 2);
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
            CreateGameObjectButtonSystem("testObject", "Hammer", _inventoryBag, true, (_inventoryBag.GetComponent<RectTransform>().rect.width / 10) / 2, (_inventoryBag.GetComponent<RectTransform>().rect.width / 10) / 2, (_inventoryBag.GetComponent<RectTransform>().rect.width / 10), (_inventoryBag.GetComponent<RectTransform>().rect.width / 10), Color.blue, false);
        }

    }
}
