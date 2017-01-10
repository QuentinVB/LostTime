using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEditor;

public class GameMapScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _GameMapPanel;
    private GameObject _userInterface;
    private GameObject _systemPanel;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _systemPanel = GameObject.Find("SystemPanel");
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if(GameObject.Find("SystemConfigurationPanel") == true)
        {
            Destroy(GameObject.Find("SystemConfigurationPanel"));
        }
        if (GameObject.Find("QuestBookPanel") == true)
        {
            Destroy(GameObject.Find("QuestBookPanel"));
        }
        if (GameObject.Find("InventoryBag") == true)
        {
            Destroy(GameObject.Find("InventoryBag"));
        }

        if (GameObject.Find("GameMapPanel") == false)
        {
            _GameMapPanel = new GameObject("GameMapPanel");
            _GameMapPanel.AddComponent<RectTransform>();
            _GameMapPanel.transform.SetParent(_userInterface.gameObject.transform, true);
            _GameMapPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
            _GameMapPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            _GameMapPanel.transform.SetParent(_systemPanel.gameObject.transform, true);
            _GameMapPanel.AddComponent<Image>();
            _GameMapPanel.GetComponent<Image>().sprite = _userInterface.GetComponent<Monitoring>().MapPanel;




            GameObject ButtonLeave = new GameObject("ButtonLeaveMap");
            ButtonLeave.AddComponent<RectTransform>();
            ButtonLeave.transform.SetParent(_GameMapPanel.gameObject.transform, true);
            ButtonLeave.GetComponent<RectTransform>().sizeDelta = new Vector2(_GameMapPanel.GetComponent<RectTransform>().rect.width / 15, _GameMapPanel.GetComponent<RectTransform>().rect.width / 15);
            ButtonLeave.GetComponent<RectTransform>().anchoredPosition = new Vector2(_GameMapPanel.GetComponent<RectTransform>().rect.width / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2,
                                                                                    _GameMapPanel.GetComponent<RectTransform>().rect.height / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2);
            ButtonLeave.AddComponent<LeavePanelScript>();
            Image y = ButtonLeave.AddComponent<Image>();
            y.color = Color.red;
        }
        else
        {
            Destroy(_GameMapPanel);
        }
        
    }

}
