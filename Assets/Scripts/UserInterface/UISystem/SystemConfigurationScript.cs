using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SystemConfigurationScript : MonoBehaviour, IPointerDownHandler
{

    private GameObject _SystemConfigurationPanel;
    private GameObject _userInterface;
    private GameObject _systemPanel;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
        _systemPanel = GameObject.Find("SystemPanel");
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("QuestBookPanel") == true)
        {
            Destroy(GameObject.Find("QuestBookPanel"));
        }
        if (GameObject.Find("GameMapPanel") == true)
        {
            Destroy(GameObject.Find("GameMapPanel"));
        }

        if (GameObject.Find("SystemConfigurationPanel") == false)
        {
            _SystemConfigurationPanel = new GameObject("SystemConfigurationPanel");
            _SystemConfigurationPanel.AddComponent<RectTransform>();
            _SystemConfigurationPanel.transform.SetParent(_userInterface.gameObject.transform, true);
            _SystemConfigurationPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
            _SystemConfigurationPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            Image x = _SystemConfigurationPanel.AddComponent<Image>();
            x.color = Color.grey;
            _SystemConfigurationPanel.transform.SetParent(_systemPanel.gameObject.transform, true);

            GameObject ButtonLeave = new GameObject("ButtonLeaveConfiguration");
            ButtonLeave.AddComponent<RectTransform>();
            ButtonLeave.transform.SetParent(_SystemConfigurationPanel.gameObject.transform, true);
            ButtonLeave.GetComponent<RectTransform>().sizeDelta = new Vector2(_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 15, _SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 15);
            ButtonLeave.GetComponent<RectTransform>().anchoredPosition = new Vector2(_SystemConfigurationPanel.GetComponent<RectTransform>().rect.width / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2,
                                                                                    _SystemConfigurationPanel.GetComponent<RectTransform>().rect.height / 2 - ButtonLeave.GetComponent<RectTransform>().rect.width / 2);
            ButtonLeave.AddComponent<LeavePanelScript>();
            Image y = ButtonLeave.AddComponent<Image>();
            y.color = Color.red;
        }
        else
        {
            Destroy(_SystemConfigurationPanel);
        }

    }
}
