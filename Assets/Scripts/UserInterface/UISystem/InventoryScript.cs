using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _userInterface;
    private string _LastItemOpen;

    private bool _PanelIsActivated;
    private bool _launchPanelAnimation;
    private bool _ItemDescriptionPanelActivated;
    private bool _launchItemDescriptionPanelAnimation;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        GameObject.Find("InventoryControllerImage").GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
        GameObject.Find("InventoryControllerImage").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
    public virtual void OnPointerDown(PointerEventData InventoryBag)
    {
        Inventaire();
    }

    private void Update()
    {
        #region PanelInventoryBagAnimationController

        if (GameObject.Find("InventoryBag") == true && _PanelIsActivated == true && _launchPanelAnimation == true)
        {
            _launchPanelAnimation = _userInterface.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("InventoryBag",
                0, 0, -1);
        }
        else if (GameObject.Find("InventoryBag") == true && _PanelIsActivated == false && _launchPanelAnimation == true)
        {
            _launchPanelAnimation = _userInterface.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("InventoryBag",
                (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.height / 2), 1);
        }
        #endregion

        #region DescriptionItemPanelAnimationController

        if (GameObject.Find("DescriptionItem") == true && _ItemDescriptionPanelActivated == true && _launchItemDescriptionPanelAnimation == true)
        {
            _launchItemDescriptionPanelAnimation = _userInterface.GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceLeftToRight("DescriptionItem",
                (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 2) +
                    (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 6), 0, 1);
        }
        else if (GameObject.Find("DescriptionItem") == true && _ItemDescriptionPanelActivated == false && _launchItemDescriptionPanelAnimation == true)
        {
            _launchItemDescriptionPanelAnimation = _userInterface.GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyRightToLeft("DescriptionItem",
                (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 6), 
                -1);
        }
        #endregion
    }

    public void Inventaire()
    {
        if (GameObject.Find("QuestBookPanel") == true)
        {
            GameObject.Find("QuestBook").GetComponent<QuestBookScript>().DestroyPanel();
        }

        if (GameObject.Find("GameMapPanel") == true)
        {
            GameObject.Find("GameMap").GetComponent<GameMapScript>().DestroyPanel();
        }

        if (GameObject.Find("SystemConfigurationPanel") == true)
        {
            GameObject.Find("SystemConfiguration").GetComponent<SystemConfigurationScript>().DestroyPanel();
        }

        if (GameObject.Find("InventoryBag") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("InventoryBag", GameObject.Find("Canvas"), true,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height,
                0, (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height * 3) / 4, Color.grey);

            _userInterface.GetComponent<ImageMonitoring>().PutBackGroundImageOnGameObject("InventoryBagTexture", "InventoryBag", _userInterface.GetComponent<ImageMonitoring>().GetBackGround5,
                false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround, false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround,
                false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround, false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround, 0, 0);


            //_userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("ButtonLeaveConfiguration", GameObject.Find("InventoryBag"), true,
            //    GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 15,
            //    GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 15,
            //    GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 2 - GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 30,
            //    GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 30, Color.red);
            //GameObject.Find("ButtonLeaveConfiguration").AddComponent<Button>();
            //GameObject.Find("ButtonLeaveConfiguration").GetComponent<Button>().onClick.AddListener(() => DestroyPanel());
            

            _PanelIsActivated = true;
            _launchPanelAnimation = true;
            ShowInventoryObject();
        }
        else
        {
            _PanelIsActivated = false;
            _ItemDescriptionPanelActivated = false;
            _launchPanelAnimation = true;
        }
    }

    public void DestroyPanel()
    {
        _PanelIsActivated = false;
        _ItemDescriptionPanelActivated = false;
        _launchPanelAnimation = true;
    }

    private void ShowInventoryObject()
    {
        int position = 1;
        int tmpX = 0;
        int tmpY = 1;

        for (int var = 0; var < _userInterface.GetComponent<InventaireScript>().GetInventoryItem.Count; var++)
        {
            if (position == 1)
            {
                tmpX = 1;
                tmpY = 1;
            }
            else if (position == 2)
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
                                        Color.clear,
                                        var);
            if (position == 6)
            {
                position = 0;
            }
            else
            {
                position++;
            }
        }
    }

    private void ShowItemDetail(string ItemName, string ItemDescription, bool UsefulItem, bool RareItem, bool QuestItem)
    {
        
        if (GameObject.Find("DescriptionItem") == false)
        {
            _LastItemOpen = ItemName;

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("DescriptionItem", GameObject.Find("InventoryBag"), true,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 3,
                GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.height,
                (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("InventoryBag").GetComponent<RectTransform>().rect.width / 6),
                0, _userInterface.GetComponent<ImageMonitoring>().GetBackGround5);

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
            _ItemDescriptionPanelActivated = true;
            _launchItemDescriptionPanelAnimation = true;
        }
        else
        {
            if(_LastItemOpen != ItemName)
            {
                _LastItemOpen = ItemName;
                GameObject.Find("ItemNameLabel").GetComponent<Text>().text = ItemName;
                GameObject.Find("ItemDescriptionLabel").GetComponent<Text>().text = ItemDescription;
                if (UsefulItem == true)
                {
                    GameObject.Find("ItemUsefulLabel").GetComponent<Text>().text = "Item utilisable";
                }
                else
                {
                    GameObject.Find("ItemUsefulLabel").GetComponent<Text>().text = "Item Inutilisable";
                }
                if (RareItem == true)
                {
                    GameObject.Find("ItemRareLabel").GetComponent<Text>().text = "Item rare";
                }
                else
                {
                    GameObject.Find("ItemRareLabel").GetComponent<Text>().text = "Item commun";
                }
                if (QuestItem == true)
                {
                    GameObject.Find("ItemQuestLabel").GetComponent<Text>().text = "Item de quete";
                }
            }
            else
            {
                _ItemDescriptionPanelActivated = false;
                _launchItemDescriptionPanelAnimation = true;
            }
            
        }
    }

    private void createInventoryItem(string gameObjectName, GameObject setParent, bool anchoredChildToParent, float sizeDeltaX, float sizeDeltaY, float anchoredPositionX, 
        float anchoredPositionY, Color color, int var)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(gameObjectName + "Item", setParent, anchoredChildToParent, sizeDeltaX, sizeDeltaY,
            anchoredPositionX, anchoredPositionY, color);
        
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ItemLabel", 
            GameObject.Find(gameObjectName + "Item"), true,
            GameObject.Find(gameObjectName + "Item").GetComponent<RectTransform>().rect.width,
            GameObject.Find(gameObjectName + "Item").GetComponent<RectTransform>().rect.height / 8,
            0, (GameObject.Find(gameObjectName + "Item").GetComponent<RectTransform>().rect.height / 8) * 3.5f,
            _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName,
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont,
            TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(GameObject.Find(gameObjectName + "Item").GetComponent<RectTransform>().rect.height / 10)), Color.black);
        
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(gameObjectName + "ItemImage", 
            GameObject.Find(gameObjectName + "Item"), true,
            GameObject.Find(gameObjectName + "Item").GetComponent<RectTransform>().rect.width,
            (GameObject.Find(gameObjectName + "Item").GetComponent<RectTransform>().rect.height / 8) * 7,
            0, (GameObject.Find(gameObjectName + "Item").GetComponent<RectTransform>().rect.height / 8) * -0.5f,
            _userInterface.GetComponent<ImageMonitoring>().GetDownArrow);
        GameObject.Find(gameObjectName + "ItemImage").AddComponent<Button>();
        GameObject.Find(gameObjectName + "ItemImage").GetComponent<Button>().onClick.AddListener(() => ShowItemDetail(_userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemName,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetItemDescription,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetUsefulItem,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetRareItem,
                                                                                    _userInterface.GetComponent<InventaireScript>().GetInventoryItem[var].GetQuestItem));
    }
}
