using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SystemButtonScript : MonoBehaviour {

    private GameObject _userInterface;

    private GameObject _systemButton;
    private GameObject _inventoryButton;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _systemButton = GameObject.Find("ButtonSystem");
        _inventoryButton = GameObject.Find("ButtonInventory");

        _systemButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _systemButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-_systemButton.GetComponent<RectTransform>().rect.width, 0);

        _inventoryButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _inventoryButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(_systemButton.GetComponent<RectTransform>().rect.width, 0);
    }

    public void CreateSystemPanel()
    {
        if (GameObject.Find("SystemPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SystemPanel", GameObject.Find("Canvas"), true,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 8,
                (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 4) * 3,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / -2 + GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 16,
                -(GameObject.Find("ButtonSystem").GetComponent<RectTransform>().rect.height / 2), Color.grey);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("GameMap", GameObject.Find("SystemPanel"), true, 
                GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.width / 1.5f, GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 8, 0,
                GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 3);
            GameObject.Find("GameMap").AddComponent<GameMapScript>();
            GameObject.Find("GameMap").AddComponent<Image>();
            GameObject.Find("GameMap").GetComponent<Image>().sprite = _userInterface.GetComponent<ImageMonitoring>().GetMapButton;

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("QuestBook", GameObject.Find("SystemPanel"), true, 
                GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.width / 1.5f, GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 8, 0, 
                GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 8);
            GameObject.Find("QuestBook").AddComponent<QuestBookScript>();
            GameObject.Find("QuestBook").AddComponent<Image>();
            GameObject.Find("QuestBook").GetComponent<Image>().sprite = _userInterface.GetComponent<ImageMonitoring>().GetQuestButton;

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("SystemConfiguration", GameObject.Find("SystemPanel"), true, 
                GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.width / 1.5f, GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 8, 0, 
                -GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 8);
            GameObject.Find("SystemConfiguration").AddComponent<SystemConfigurationScript>();
            GameObject.Find("SystemConfiguration").AddComponent<Image>();
            GameObject.Find("SystemConfiguration").GetComponent<Image>().sprite = _userInterface.GetComponent<ImageMonitoring>().GetConfigButton;

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("Leave", GameObject.Find("SystemPanel"), true, 
                GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.width / 1.5f, GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 8, 0, 
                -GameObject.Find("SystemPanel").GetComponent<RectTransform>().rect.height / 3);
            GameObject.Find("Leave").AddComponent<LeaveScript>();
            GameObject.Find("Leave").AddComponent<Image>();
            GameObject.Find("Leave").GetComponent<Image>().sprite = _userInterface.GetComponent<ImageMonitoring>().GetLeaveButton;
        }
        else
        {
            Destroy(GameObject.Find("SystemPanel"));
        }
    }

    public void Inventaire()
    {
        if (GameObject.Find("QuestBookPanel") == true)
            Destroy(GameObject.Find("QuestBookPanel"));

        if (GameObject.Find("GameMapPanel") == true)
            Destroy(GameObject.Find("GameMapPanel"));

        if (GameObject.Find("SystemConfigurationPanel") == true)
            Destroy(GameObject.Find("SystemConfigurationPanel"));

        if (GameObject.Find("InventoryBag") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("InventoryBag", GameObject.Find("Canvas"), true,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2 - GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2,
                0, Color.grey);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("ButtonLeaveConfiguration", GameObject.Find("InventoryBag"), true,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 15,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 15,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 2 - GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 30,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 30, Color.red);
            GameObject.Find("ButtonLeaveConfiguration").AddComponent<LeavePanelScript>();

            ShowInventoryObject();
        }
        else
        {
            Destroy(GameObject.Find("InventoryBag"));
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
                                        GameObject.Find("InventoryBag"),
                                        true,
                                        (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 32) * 8,
                                        (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.height / 26) * 8,
                                        -(GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 32) * (10 * tmpX),
                                        (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.height / 26) * (5 * tmpY),
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
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("DescriptionItem", GameObject.Find("InventoryBag"), true,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 4,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.height / 2,
                (-GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 8),
                0, Color.white);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ItemNameLabel", GameObject.Find("DescriptionItem"), true,
                GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.width,
                GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8,
                0, (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8) * 3.5f,
                ItemName, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter,
                FontStyle.Bold, (int)(GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 16), Color.black);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ItemDescriptionLabel", GameObject.Find("DescriptionItem"), true,
                GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.width,
                (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8) * 2,
                0, (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8) * 1.5f,
                ItemDescription, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter,
                FontStyle.Bold, (int)(GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 16), Color.black);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ItemUsefulLabel", GameObject.Find("DescriptionItem"), true,
                GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.width,
                (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8),
                0, (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8) * -0.5f,
                ItemDescription, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter,
                FontStyle.Bold, (int)(GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 16), Color.black);
            if (UsefulItem == true)
            {
                GameObject.Find("ItemUsefulLabel").GetComponent<Text>().text = "Item utilisable";
            }
            else
            {
                GameObject.Find("ItemUsefulLabel").GetComponent<Text>().text = "Item Inutilisable";
            }

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ItemRareLabel", GameObject.Find("DescriptionItem"), true,
               GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.width,
               (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8),
               0, (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8) * -1.5f,
               ItemDescription, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter,
               FontStyle.Bold, (int)(GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 16), Color.black);
            if (RareItem == true)
            {
                GameObject.Find("ItemRareLabel").GetComponent<Text>().text = "Item rare";
            }
            else
            {
                GameObject.Find("ItemRareLabel").GetComponent<Text>().text = "Item commun";
            }

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ItemQuestLabel", GameObject.Find("DescriptionItem"), true,
               GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.width,
               (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8),
               0, (GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 8) * -2.5f,
               ItemDescription, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter,
               FontStyle.Bold, (int)(GameObject.Find("DescriptionItem").GetComponent<RectTransform>().rect.height / 16), Color.black);
            if (QuestItem == true)
            {
                GameObject.Find("ItemQuestLabel").GetComponent<Text>().text = "Item de quete";
            }
        }
        else
        {
            Destroy(GameObject.Find("DescriptionItem"));
        }
    }

    private void createInventoryItem(string gameObjectName, GameObject setParent, bool anchoredChildToParent, float sizeDeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY, Color color, int var)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(gameObjectName, setParent, anchoredChildToParent, sizeDeltaX, sizeDeltaY,
            anchoredPositionX, anchoredPositionY, color);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ItemLabel", GameObject.Find(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName), true,
            GameObject.Find(gameObjectName).GetComponent<RectTransform>().rect.width,
            GameObject.Find(gameObjectName).GetComponent<RectTransform>().rect.height / 8,
            0, (GameObject.Find(gameObjectName).GetComponent<RectTransform>().rect.height / 8) * 3.5f,
            _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName,
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont,
            TextAnchor.MiddleCenter, FontStyle.Bold, (int)(GameObject.Find(gameObjectName).GetComponent<RectTransform>().rect.height / 16), Color.black);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(gameObjectName + "ItemImage", GameObject.Find(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName), true,
            GameObject.Find(gameObjectName).GetComponent<RectTransform>().rect.width,
            (GameObject.Find(gameObjectName).GetComponent<RectTransform>().rect.height / 8) * 7,
            0, (GameObject.Find(gameObjectName).GetComponent<RectTransform>().rect.height / 8) * -0.5f,
            _userInterface.GetComponent<ImageMonitoring>().GetDownArrow);
        GameObject.Find(gameObjectName + "ItemImage").AddComponent<Button>();
        GameObject.Find(gameObjectName + "ItemImage").GetComponent<Button>().onClick.AddListener(() => ShowItemDetail(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemDescription,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetUsefulItem,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetRareItem,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetQuestItem));
    }
}
