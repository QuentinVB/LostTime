using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameMapScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _GameMapPanel;
    private GameObject _userInterface;
    private GameObject _systemPanel;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _userInterface.AddComponent<Canvas>();
        _systemPanel = GameObject.Find("SystemPanel");
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("GameMapPanel") == false)
        {
            _GameMapPanel = new GameObject("GameMapPanel");
            _GameMapPanel.AddComponent<RectTransform>();
            _GameMapPanel.transform.SetParent(_userInterface.gameObject.transform, true);
            _GameMapPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
            _GameMapPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            Image x = _GameMapPanel.AddComponent<Image>();
            x.color = Color.grey;
            _GameMapPanel.transform.SetParent(_systemPanel.gameObject.transform, true);


            GameObject ButtonLeave = new GameObject("ButtonLeaveMap");
            ButtonLeave.AddComponent<RectTransform>();
            ButtonLeave.transform.SetParent(_GameMapPanel.gameObject.transform, true);
            ButtonLeave.GetComponent<RectTransform>().sizeDelta = new Vector2(_GameMapPanel.GetComponent<RectTransform>().rect.width / 25, _GameMapPanel.GetComponent<RectTransform>().rect.width / 25);
            ButtonLeave.GetComponent<RectTransform>().anchoredPosition = new Vector2(_GameMapPanel.GetComponent<RectTransform>().rect.width / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2,
                                                                                    _GameMapPanel.GetComponent<RectTransform>().rect.height / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2);
            _GameMapPanel.AddComponent<LeavePanelScript>();
            Image y = ButtonLeave.AddComponent<Image>();
            y.color = Color.red;
        }
        else
        {
            Destroy(_GameMapPanel);
        }
        
    }

}
