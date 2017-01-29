using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameMapScript : MonoBehaviour, IPointerDownHandler
{
    private bool _isMapPanelActivated;
    private bool _launchMapAnimation;


    private void Update()
    {
        if (GameObject.Find("GameMapPanel") && _isMapPanelActivated == true && _launchMapAnimation == true)
        {
            _launchMapAnimation = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("GameMapPanel",
                0, 0, -1);
        }else if(GameObject.Find("GameMapPanel") && _isMapPanelActivated == false && _launchMapAnimation == true)
        {
            _launchMapAnimation = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("GameMapPanel",
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.height / 2, 1);
        }
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("SystemConfigurationPanel") == true)
        {
            GameObject.Find("SystemConfiguration").GetComponent<SystemConfigurationScript>().DestroyPanel();
        }

        if (GameObject.Find("QuestBookPanel") == true)
        {
            GameObject.Find("QuestBook").GetComponent<QuestBookScript>().DestroyPanel();
        }

        if (GameObject.Find("InventoryBag") == true)
        {
            GameObject.Find("ButtonInventory").GetComponent<InventoryScript>().DestroyPanel();
        }

        if (GameObject.Find("GameMapPanel") == false)
        {
            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("GameMapPanel", GameObject.Find("Canvas"), true, 
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height,
                0, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2, 
                GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetBackGround1);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("Map", GameObject.Find("GameMapPanel"), true,
                (GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.height / 10) * 8,
                (GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.height / 10) * 8,
                0, 0, GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetMapPanel);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("ButtonLeave", GameObject.Find("GameMapPanel"), true,
                GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.width / 15, GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.width / 15,
                GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.width / 2 - GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.width / 30,
                GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.height / 30, Color.red);
            GameObject.Find("ButtonLeave").AddComponent<Button>();
            GameObject.Find("ButtonLeave").GetComponent<Button>().onClick.AddListener(() => DestroyPanel());

            _isMapPanelActivated = true;
            _launchMapAnimation = true;
        }
        else
        {
            _isMapPanelActivated = false;
            _launchMapAnimation = true;
        }
        
    }

    public void DestroyPanel()
    {
        _isMapPanelActivated = false;
        _launchMapAnimation = true;
    }

}
