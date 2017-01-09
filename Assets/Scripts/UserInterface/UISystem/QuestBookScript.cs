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
        if(GameObject.Find("InventoryBag") == true)
        {
            Destroy(GameObject.Find("InventoryBag"));
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

            ShowQuestBook();
        }
        else
        {
            Destroy(_QuestBookPanel);
        }

    }

    private void ShowQuestBook()
    {
        CreateActiveQuestPanel(-2.5f, -1f, "ActiveQuestPanelBackGround", "ActiveQuest");
        CreateActiveQuestPanel(2.5f, -1f, "FinishedQuestPanelBackGround", "FinishedQuest");

        ShowQuest();
    }

    private void CreateActiveQuestPanel(float PanelBackGroundX, float BackGroundPanelY, string PanelName, string Label)
    {

        GameObject gameobject = new GameObject(PanelName);
        gameobject.AddComponent<RectTransform>();
        gameobject.transform.SetParent(_QuestBookPanel.transform, true);
        gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2((_QuestBookPanel.GetComponent<RectTransform>().rect.width / 10) * 4, (_QuestBookPanel.GetComponent<RectTransform>().rect.height / 10) * 8 );
        gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2((_QuestBookPanel.GetComponent<RectTransform>().rect.width / 10) * PanelBackGroundX, (_QuestBookPanel.GetComponent<RectTransform>().rect.height / 10) * BackGroundPanelY);
        Image x = gameobject.AddComponent<Image>();
        x.color = Color.white;

        GameObject gameobjectLabel = new GameObject(PanelName +"Label");
        gameobjectLabel.AddComponent<RectTransform>();
        gameobjectLabel.transform.SetParent(gameobject.transform, true);
        gameobjectLabel.GetComponent<RectTransform>().sizeDelta = new Vector2(gameobject.GetComponent<RectTransform>().rect.width, _QuestBookPanel.GetComponent<RectTransform>().rect.height / 10);
        gameobjectLabel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, _QuestBookPanel.GetComponent<RectTransform>().rect.height / 10 * 3.5f);
        gameobjectLabel.AddComponent<Text>();
        gameobjectLabel.GetComponent<Text>().text = Label;
        gameobjectLabel.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
        gameobjectLabel.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
        gameobjectLabel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
        gameobjectLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
        gameobjectLabel.GetComponent<Text>().fontSize = (int)(gameobjectLabel.GetComponent<RectTransform>().rect.height / 2);
        gameobjectLabel.GetComponent<Text>().color = Color.black;



    }

    private void ShowQuest()
    {
        float tmpActiveQuest = 1;
        float tmpFinishedQuest = 1;

        for (int var = 0; var < _userInterface.GetComponent<QuestBook>().GetQuestBook.Count; var++)
        {
            if (_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestIsFinished == false)
            {
                GameObject ActiveQuestObject = new GameObject(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName);
                ActiveQuestObject.AddComponent<RectTransform>();
                ActiveQuestObject.transform.SetParent(GameObject.Find("ActiveQuestPanelBackGroundLabel").transform, true);
                ActiveQuestObject.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.width, GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height);
                ActiveQuestObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height * tmpActiveQuest);
                ActiveQuestObject.AddComponent<Button>();
                ActiveQuestObject.AddComponent<Text>();
                ActiveQuestObject.GetComponent<Text>().text = _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName;
                ActiveQuestObject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
                ActiveQuestObject.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
                ActiveQuestObject.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
                ActiveQuestObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
                ActiveQuestObject.GetComponent<Text>().fontSize = (int)(ActiveQuestObject.GetComponent<RectTransform>().rect.height / 2);
                ActiveQuestObject.GetComponent<Text>().color = Color.black;

                tmpActiveQuest++;
            }
            else
            {
                GameObject FinishedQuestObject = new GameObject(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName);
                FinishedQuestObject.AddComponent<RectTransform>();
                FinishedQuestObject.transform.SetParent(GameObject.Find("FinishedQuestPanelBackGroundLabel").transform, true);
                FinishedQuestObject.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.width, GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height);
                FinishedQuestObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height * tmpFinishedQuest);
                FinishedQuestObject.AddComponent<Button>();
                FinishedQuestObject.AddComponent<Text>();
                FinishedQuestObject.GetComponent<Text>().text = _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName;
                FinishedQuestObject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
                FinishedQuestObject.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
                FinishedQuestObject.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
                FinishedQuestObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
                FinishedQuestObject.GetComponent<Text>().fontSize = (int)(FinishedQuestObject.GetComponent<RectTransform>().rect.height / 2);
                FinishedQuestObject.GetComponent<Text>().color = Color.black;

                tmpFinishedQuest++;
            }

        }
    }
}
