using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SystemButtonScript : MonoBehaviour {

    private GameObject _userInterface;
    private GameObject _systemButton;
    private GameObject _inventoryButton;
    private GameObject _systemButtonImage;

    private bool _SystemPanelActivated;
    private bool _SystemPanelAnimation;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _systemButton = GameObject.Find("ButtonSystem");
        _inventoryButton = GameObject.Find("ButtonInventory");
        _systemButtonImage = GameObject.Find("SystemControllerImage");

        _systemButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _systemButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-_systemButton.GetComponent<RectTransform>().rect.width, 0);

        _systemButtonImage.transform.SetParent(_systemButton.transform, true);
        _systemButtonImage.GetComponent<RectTransform>().sizeDelta = _systemButton.GetComponent<RectTransform>().sizeDelta;
        _systemButtonImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        _inventoryButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 12, Screen.width / 12);
        _inventoryButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(_systemButton.GetComponent<RectTransform>().rect.width, 0);
        _inventoryButton.AddComponent<InventoryScript>();
    }

    private void Update()
    {
        if(GameObject.Find("SystemPanel") == true && _SystemPanelActivated == true && _SystemPanelAnimation == true)
        {
            _userInterface.GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SystemControllerImage", 0, 0, 0, 0, -1, 10);
            _SystemPanelAnimation = _userInterface.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("SystemPanel",
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / -2 + GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 16,
                -(GameObject.Find("ButtonSystem").GetComponent<RectTransform>().rect.height / 2), -1);
        }else if(GameObject.Find("SystemPanel") == true && _SystemPanelActivated == false && _SystemPanelAnimation == true)
        {
            _SystemPanelAnimation = _userInterface.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("SystemPanel",
                (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height) - (GameObject.Find("ButtonSystem").GetComponent<RectTransform>().rect.height / 2), 1);
            _userInterface.GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SystemControllerImage", 0, 0, 0, 0, 1, 10);


            /// Petit pb de destroy object lors du Destroy de l'object SystemPanel
            /// 
            if (GameObject.Find("QuestBookPanel") == true)
            {
                Destroy(GameObject.Find("QuestBookPanel"));
            }

            if (GameObject.Find("SystemConfigurationPanel") == true)
            {
                Destroy(GameObject.Find("SystemConfigurationPanel"));
            }

            if (GameObject.Find("GameMapPanel") == true)
            {
                Destroy(GameObject.Find("GameMapPanel"));
            }
        }
    
    }

    public void CreateSystemPanel()
    {
        if (GameObject.Find("SystemPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("SystemPanel", GameObject.Find("Canvas"), true,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 8,
                (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 4) * 3,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / -2 + GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 16,
                (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height) - (GameObject.Find("ButtonSystem").GetComponent<RectTransform>().rect.height / 2), Color.grey);

            _userInterface.GetComponent<ImageMonitoring>().PutBackGroundImageOnGameObject("SystemPanelSprite", "SystemPanel",
                _userInterface.GetComponent<ImageMonitoring>().GetWoodBackGround,
                true, _userInterface.GetComponent<ImageMonitoring>().GetMetalCircle,
                true, _userInterface.GetComponent<ImageMonitoring>().GetMetalCircle,
                false, _userInterface.GetComponent<ImageMonitoring>().GetWoodBackGround,
                false, _userInterface.GetComponent<ImageMonitoring>().GetWoodBackGround,
                10, 10);

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
            GameObject.Find("Leave").AddComponent<Button>();
            GameObject.Find("Leave").GetComponent<Button>().onClick.AddListener(() => GoBackToMenu());
            GameObject.Find("Leave").AddComponent<Image>();
            GameObject.Find("Leave").GetComponent<Image>().sprite = _userInterface.GetComponent<ImageMonitoring>().GetLeaveButton;
            

            _SystemPanelActivated = true;
            _SystemPanelAnimation = true;
        }
        else
        {
            if (GameObject.Find("QuestBookPanel") == true)
            {
                GameObject.Find("QuestBook").GetComponent<QuestBookScript>().DestroyPanel();
            }

            if (GameObject.Find("SystemConfigurationPanel") == true)
            {
                GameObject.Find("SystemConfiguration").GetComponent<SystemConfigurationScript>().DestroyPanel();
            }

            if (GameObject.Find("GameMapPanel") == true)
            {
                GameObject.Find("GameMap").GetComponent<GameMapScript>().DestroyPanel();
            }

            _SystemPanelActivated = false;
            _SystemPanelAnimation = true;
        }
    }


    private void GoBackToMenu()
    {
        SceneManager.LoadScene("LostTimeMenuGame");
    }
}
