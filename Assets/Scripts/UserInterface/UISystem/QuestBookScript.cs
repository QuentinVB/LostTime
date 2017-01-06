using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestBookScript : MonoBehaviour, IPointerDownHandler
{

    private GameObject _QuestBookPanel;
    private GameObject _userInterface;
    private GameObject _systemPanel;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _systemPanel = GameObject.Find("SystemPanel");
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("SystemConfigurationPanel") == true)
        {
            Destroy(GameObject.Find("SystemConfigurationPanel"));
        }
        if (GameObject.Find("GameMapPanel") == true)
        {
            Destroy(GameObject.Find("GameMapPanel"));
        }

        if (GameObject.Find("QuestBookPanel") == false)
        {
            _QuestBookPanel = new GameObject("QuestBookPanel");
            _QuestBookPanel.AddComponent<RectTransform>();
            _QuestBookPanel.transform.SetParent(_userInterface.gameObject.transform, true);
            _QuestBookPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
            _QuestBookPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            Image x = _QuestBookPanel.AddComponent<Image>();
            x.color = Color.grey;
            _QuestBookPanel.transform.SetParent(_systemPanel.gameObject.transform, true);

            GameObject ButtonLeave = new GameObject("ButtonLeaveQuest");
            ButtonLeave.AddComponent<RectTransform>();
            ButtonLeave.transform.SetParent(_QuestBookPanel.gameObject.transform, true);
            ButtonLeave.GetComponent<RectTransform>().sizeDelta = new Vector2(_QuestBookPanel.GetComponent<RectTransform>().rect.width / 15, _QuestBookPanel.GetComponent<RectTransform>().rect.width / 15);
            ButtonLeave.GetComponent<RectTransform>().anchoredPosition = new Vector2(_QuestBookPanel.GetComponent<RectTransform>().rect.width / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2,
                                                                                    _QuestBookPanel.GetComponent<RectTransform>().rect.height / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2);
            ButtonLeave.AddComponent<LeavePanelScript>();
            Image y = ButtonLeave.AddComponent<Image>();
            y.color = Color.red;
        }
        else
        {
            Destroy(_QuestBookPanel);
        }

    }
}
