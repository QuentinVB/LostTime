using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SystemButtonScript : MonoBehaviour {

    private GameObject _userInterface;

    private GameObject _systemButton;
    private GameObject _inventoryButton;
    private GameObject _QuestBookPanel;

    private GameObject _systemPanel;
    private GameObject _inventoryBag;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _systemButton = GameObject.Find("ButtonSystem");
        _inventoryButton = GameObject.Find("ButtonInventory");

        _systemButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _inventoryButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
    }

    public void CreateSystemPanel()
    {
        if (GameObject.Find("SystemPanel") == false)
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
        }
        else
        {
            Destroy(_systemPanel);
        }
    }


    public void Inventaire()
    {
        if (GameObject.Find("QuestBookPanel") == true)
        {
            Destroy(GameObject.Find("QuestBookPanel"));
        }
        if (GameObject.Find("GameMapPanel") == true)
        {
            Destroy(GameObject.Find("GameMapPanel"));
        }
        if (GameObject.Find("SystemConfigurationPanel") == true)
        {
            Destroy(GameObject.Find("SystemConfigurationPanel"));
        }

        if (GameObject.Find("InventoryBag") == false)
        {
            _inventoryBag = new GameObject("InventoryBag");
            _inventoryBag.AddComponent<RectTransform>();
            _inventoryBag.transform.SetParent(_userInterface.gameObject.transform, true);
            _inventoryBag.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
            _inventoryBag.GetComponent<RectTransform>().anchoredPosition = new Vector2((_inventoryBag.GetComponent<RectTransform>().rect.width / 2) - (_inventoryButton.GetComponent<RectTransform>().rect.width), 0);
            Image x = _inventoryBag.AddComponent<Image>();
            x.color = Color.grey;

            GameObject ButtonLeave = new GameObject("ButtonLeaveConfiguration");
            ButtonLeave.AddComponent<RectTransform>();
            ButtonLeave.transform.SetParent(_inventoryBag.gameObject.transform, true);
            ButtonLeave.GetComponent<RectTransform>().sizeDelta = new Vector2(_inventoryBag.GetComponent<RectTransform>().rect.width / 15, _inventoryBag.GetComponent<RectTransform>().rect.width / 15);
            ButtonLeave.GetComponent<RectTransform>().anchoredPosition = new Vector2(_inventoryBag.GetComponent<RectTransform>().rect.width / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2,
                                                                                    _inventoryBag.GetComponent<RectTransform>().rect.height / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2);
            ButtonLeave.AddComponent<LeavePanelScript>();
            Image y = ButtonLeave.AddComponent<Image>();
            y.color = Color.red;

            ShowInventoryObject();
        }
        else
        {
            Destroy(_inventoryBag);
        }
    }

    private void ShowInventoryObject()
    {
        int position = 1;
        int tmpX = 0;
        int tmpY = 1;

        for (int var = 0; var < _userInterface.GetComponent<InventaireScript>().GetInventoryItem.Count; var++)
        {
            if(position == 1)
            {
                tmpX = 1;
                tmpY = 1;
            }
            else if(position == 2)
            {
                tmpX = 0;
                tmpY = 1;
            }
            else if (position == 3)
            {
                tmpX = -1;
                tmpY = 1;
            }
            else if (position == 4)
            {
                tmpX = 1;
                tmpY = -1;
            }
            else if (position == 5)
            {
                tmpX = 0;
                tmpY = -1;
            }
            else if (position == 6)
            {
                tmpX = -1;
                tmpY = -1;
            }
            createInventoryItem(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName,
                                        _inventoryBag,
                                        true,
                                        (_inventoryBag.GetComponent<RectTransform>().rect.width / 32) * 8,
                                        (_inventoryBag.GetComponent<RectTransform>().rect.height / 26) * 8,
                                        -(_inventoryBag.GetComponent<RectTransform>().rect.width / 32) * (10 * tmpX),
                                        (_inventoryBag.GetComponent<RectTransform>().rect.height / 26) * (5 * tmpY),
                                        Color.white,
                                        var);

            if (position == 6)
            {
                position = 0;
            }else
            {
                position++;
            }
        }


    }

    private void ShowItemDetail(string ItemName, string ItemDescription, bool UsefulItem, bool RareItem, bool QuestItem)
    {
        if (GameObject.Find("DescriptionItem") == false)
        {
            GameObject gameObject = new GameObject("DescriptionItem");
            gameObject.AddComponent<RectTransform>();
            gameObject.transform.SetParent(_inventoryBag.transform, true);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(_inventoryBag.GetComponent<RectTransform>().rect.width / 4, _inventoryBag.GetComponent<RectTransform>().rect.height / 2);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(_inventoryBag.GetComponent<RectTransform>().rect.width / 2) - (gameObject.GetComponent<RectTransform>().rect.width / 2), 0);
            Image x = gameObject.AddComponent<Image>();
            x.color = Color.white;

            GameObject ItemNameLabel = new GameObject("ItemNameLabel");
            ItemNameLabel.AddComponent<RectTransform>();
            ItemNameLabel.transform.SetParent(GameObject.Find("DescriptionItem").transform, true);
            ItemNameLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((gameObject.GetComponent<RectTransform>().rect.width), (gameObject.GetComponent<RectTransform>().rect.height / 8));
            ItemNameLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (gameObject.GetComponent<RectTransform>().rect.height / 8) * 3.5f);
            ItemNameLabel.AddComponent<Text>();
            ItemNameLabel.GetComponent<Text>().text = ItemName;
            ItemNameLabel.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            ItemNameLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            ItemNameLabel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            ItemNameLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
            ItemNameLabel.GetComponent<Text>().fontSize = (int)(ItemNameLabel.GetComponent<RectTransform>().rect.height / 2);
            ItemNameLabel.GetComponent<Text>().color = Color.black;

            GameObject ItemDescriptionLabel = new GameObject("ItemDescriptionLabel");
            ItemDescriptionLabel.AddComponent<RectTransform>();
            ItemDescriptionLabel.transform.SetParent(GameObject.Find("DescriptionItem").transform, true);
            ItemDescriptionLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((gameObject.GetComponent<RectTransform>().rect.width), (gameObject.GetComponent<RectTransform>().rect.height / 8) * 2);
            ItemDescriptionLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (gameObject.GetComponent<RectTransform>().rect.height / 8) * 1.5f);
            ItemDescriptionLabel.AddComponent<Text>();
            ItemDescriptionLabel.GetComponent<Text>().text = ItemDescription;
            ItemDescriptionLabel.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            ItemDescriptionLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            ItemDescriptionLabel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            ItemDescriptionLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
            ItemDescriptionLabel.GetComponent<Text>().fontSize = (int)(ItemNameLabel.GetComponent<RectTransform>().rect.height / 2);
            ItemDescriptionLabel.GetComponent<Text>().color = Color.black;

            GameObject ItemUsefulLabel = new GameObject("ItemUsefulLabel");
            ItemUsefulLabel.AddComponent<RectTransform>();
            ItemUsefulLabel.transform.SetParent(GameObject.Find("DescriptionItem").transform, true);
            ItemUsefulLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((gameObject.GetComponent<RectTransform>().rect.width), gameObject.GetComponent<RectTransform>().rect.height / 8);
            ItemUsefulLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (gameObject.GetComponent<RectTransform>().rect.height / 8) * -0.5f);
            ItemUsefulLabel.AddComponent<Text>();
            if (UsefulItem == true)
            {
                ItemUsefulLabel.GetComponent<Text>().text = "Item utilisable";
            }
            else
            {
                ItemUsefulLabel.GetComponent<Text>().text = "Item Inutilisable";
            }
            ItemUsefulLabel.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            ItemUsefulLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            ItemUsefulLabel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            ItemUsefulLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
            ItemUsefulLabel.GetComponent<Text>().fontSize = (int)(ItemUsefulLabel.GetComponent<RectTransform>().rect.height / 2);
            ItemUsefulLabel.GetComponent<Text>().color = Color.black;

            GameObject ItemRareLabel = new GameObject("ItemRareLabel");
            ItemRareLabel.AddComponent<RectTransform>();
            ItemRareLabel.transform.SetParent(GameObject.Find("DescriptionItem").transform, true);
            ItemRareLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((gameObject.GetComponent<RectTransform>().rect.width), gameObject.GetComponent<RectTransform>().rect.height / 8);
            ItemRareLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (gameObject.GetComponent<RectTransform>().rect.height / 8) * -1.5f);
            ItemRareLabel.AddComponent<Text>();
            if (RareItem == true)
            {
                ItemRareLabel.GetComponent<Text>().text = "Item rare";
            }
            else
            {
                ItemRareLabel.GetComponent<Text>().text = "Item commun";
            }
            ItemRareLabel.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            ItemRareLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            ItemRareLabel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            ItemRareLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
            ItemRareLabel.GetComponent<Text>().fontSize = (int)(ItemRareLabel.GetComponent<RectTransform>().rect.height / 2);
            ItemRareLabel.GetComponent<Text>().color = Color.black;

            GameObject ItemQuestLabel = new GameObject("ItemQuestLabel");
            ItemQuestLabel.AddComponent<RectTransform>();
            ItemQuestLabel.transform.SetParent(GameObject.Find("DescriptionItem").transform, true);
            ItemQuestLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((gameObject.GetComponent<RectTransform>().rect.width), gameObject.GetComponent<RectTransform>().rect.height / 8);
            ItemQuestLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (gameObject.GetComponent<RectTransform>().rect.height / 8) * -2.5f);
            ItemQuestLabel.AddComponent<Text>();
            if (QuestItem == true)
            {
                ItemQuestLabel.GetComponent<Text>().text = "Item de quete";
            }
            ItemQuestLabel.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            ItemQuestLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            ItemQuestLabel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            ItemQuestLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
            ItemQuestLabel.GetComponent<Text>().fontSize = (int)(ItemQuestLabel.GetComponent<RectTransform>().rect.height / 2);
            ItemQuestLabel.GetComponent<Text>().color = Color.black;
        }
        else
        {
            Destroy(GameObject.Find("DescriptionItem"));
        }
    }

    private void createInventoryItem(string gameObjectName, GameObject setParent, bool anchoredChildToParent, float sizeDeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY, Color color, int var)
    {
        GameObject gameObject = new GameObject(gameObjectName);
        gameObject.AddComponent<RectTransform>();
        gameObject.transform.SetParent(setParent.transform, anchoredChildToParent);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDeltaX, sizeDeltaY);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);
        Image x = gameObject.AddComponent<Image>();
        x.color = color;



        GameObject ItemLabel = new GameObject("ItemLabel");
        ItemLabel.AddComponent<RectTransform>();
        ItemLabel.transform.SetParent(GameObject.Find(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName).transform, true);
        ItemLabel.GetComponent<RectTransform>().sizeDelta = new Vector2((gameObject.GetComponent<RectTransform>().rect.width), gameObject.GetComponent<RectTransform>().rect.height / 8);
        ItemLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (gameObject.GetComponent<RectTransform>().rect.height / 8) * 3.5f);
        ItemLabel.AddComponent<Text>();
        ItemLabel.GetComponent<Text>().text = _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName;
        ItemLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        ItemLabel.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        ItemLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
        ItemLabel.GetComponent<Text>().fontSize = (int)(ItemLabel.GetComponent<RectTransform>().rect.height / 2);
        ItemLabel.GetComponent<Text>().color = Color.black;

        GameObject ItemImage = new GameObject("ItemImage");
        ItemImage.AddComponent<RectTransform>();
        ItemImage.AddComponent<Button>();
        ItemImage.AddComponent<Image>();
        ItemImage.transform.SetParent(GameObject.Find(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName).transform, true);
        ItemImage.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().DownArrow;
        ItemImage.GetComponent<RectTransform>().sizeDelta = new Vector2((gameObject.GetComponent<RectTransform>().rect.width), (gameObject.GetComponent<RectTransform>().rect.height / 8) * 7);
        ItemImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (gameObject.GetComponent<RectTransform>().rect.height / 8) * -0.5f);
        ItemImage.GetComponent<Button>().onClick.AddListener(() => ShowItemDetail(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemDescription,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetUsefulItem,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetRareItem,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetQuestItem));
    }

    private void CreateGameObjectButtonSystem(string gameObjectName, GameObject setParent, bool anchoredChildToParent, float sizeDeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY, Color color, bool isButton)
    {
        GameObject gameObject = new GameObject(gameObjectName);
        gameObject.AddComponent<RectTransform>();
        gameObject.transform.SetParent(setParent.transform, anchoredChildToParent);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDeltaX, sizeDeltaY);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);
        Image x = gameObject.AddComponent<Image>();
        x.color = color;
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
}
