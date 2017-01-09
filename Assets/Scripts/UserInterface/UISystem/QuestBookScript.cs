using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

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
        if (GameObject.Find("InventoryBag") == true)
        {
            Destroy(GameObject.Find("InventoryBag"));
        }

        if (GameObject.Find("QuestBookPanel") == false)
        {
            _QuestBookPanel = new GameObject("QuestBookPanel");
            _QuestBookPanel.AddComponent<RectTransform>();
            _QuestBookPanel.transform.SetParent(_userInterface.gameObject.transform, true);
            _QuestBookPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_userInterface.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height);
            _QuestBookPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(_userInterface.GetComponent<RectTransform>().rect.width / 4) + _systemPanel.GetComponent<RectTransform>().rect.width + 2, 0);
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
        gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2((_QuestBookPanel.GetComponent<RectTransform>().rect.width / 10) * 4, (_QuestBookPanel.GetComponent<RectTransform>().rect.height / 10) * 8);
        gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2((_QuestBookPanel.GetComponent<RectTransform>().rect.width / 10) * PanelBackGroundX, (_QuestBookPanel.GetComponent<RectTransform>().rect.height / 10) * BackGroundPanelY);
        Image x = gameobject.AddComponent<Image>();
        x.color = Color.white;

        GameObject gameobjectLabel = new GameObject(PanelName + "Label");
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

    private void ShowQuestDetail(string QuestName, string QuestDescription, Dictionary<string, int> QuestStep) 
    {
        if (GameObject.Find("QuestDetailBackGround") == false)
        {
            Debug.Log(QuestName);
            GameObject gameobject = new GameObject("QuestDetailBackGround");
            gameobject.AddComponent<RectTransform>();
            gameobject.transform.SetParent(_QuestBookPanel.transform, true);
            gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(_QuestBookPanel.GetComponent<RectTransform>().rect.width / 2, _QuestBookPanel.GetComponent<RectTransform>().rect.height);
            gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2((_QuestBookPanel.GetComponent<RectTransform>().rect.width) - (gameobject.GetComponent<RectTransform>().rect.width / 2), 0);
            Image x = gameobject.AddComponent<Image>();
            x.color = Color.white;

            GameObject gameObject = new GameObject("QuestDetailBackGroundLabel");
            gameObject.AddComponent<RectTransform>();
            gameObject.AddComponent<Text>();
            gameObject.transform.SetParent(UnityEngine.GameObject.Find("QuestDetailBackGround").transform, true);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(UnityEngine.GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.width, UnityEngine.GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 8);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (UnityEngine.GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 8) * 3.5f);
            gameObject.GetComponent<Text>().text = QuestName;
            gameObject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            gameObject.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
            gameObject.GetComponent<Text>().fontSize = (int)(gameObject.GetComponent<RectTransform>().rect.height / 2);
            gameObject.GetComponent<Text>().color = Color.black;

            GameObject GameObject = new GameObject("QuestDetailBackGroundLabel");
            GameObject.AddComponent<RectTransform>();
            GameObject.AddComponent<Text>();
            GameObject.transform.SetParent(GameObject.Find("QuestDetailBackGround").transform, true);
            GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 8);
            GameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 8) * 1.5f);
            GameObject.GetComponent<Text>().text = QuestDescription;
            GameObject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            GameObject.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            GameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            GameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
            GameObject.GetComponent<Text>().fontSize = (int)(GameObject.GetComponent<RectTransform>().rect.height / 2);
            GameObject.GetComponent<Text>().color = Color.black;

            GameObject Object = new GameObject("QuestDetailBackGroundLabel");
            Object.AddComponent<RectTransform>();
            Object.AddComponent<Text>();
            Object.transform.SetParent(GameObject.Find("QuestDetailBackGround").transform, true);
            Object.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 8);
            Object.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 8) * -1.5f);
            Object.GetComponent<Text>().text = "Les étapes sont :\r\n ";
            Object.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            Object.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            Object.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            Object.GetComponent<Text>().fontStyle = FontStyle.Bold;
            Object.GetComponent<Text>().fontSize = (int)(Object.GetComponent<RectTransform>().rect.height / 2);
            Object.GetComponent<Text>().color = Color.black;


        }
        else
        {
            Destroy(GameObject.Find("QuestDetailBackGround"));
        }
    }

    private void ShowQuest()
    {
        float tmpActiveQuest = 1;
        float tmpFinishedQuest = 1;

        for (int var = 0; var < _userInterface.GetComponent<QuestBook>().GetQuestBook.Count; var++)
        {
            if (_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestIsFinished == false)
            {
                tmpActiveQuest++;
            }else
            {
                tmpFinishedQuest++;
            }
            CreateActiveFinishedQuestPanel(var, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, tmpActiveQuest, tmpFinishedQuest);
        }
    }

    private void CreateActiveFinishedQuestPanel(int var, string QuestName, float tmpQuestActive, float tmpQuestFinished)
    {
        if (_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestIsFinished == false)
        {
            GameObject gameobject = new GameObject(QuestName);
            gameobject.AddComponent<RectTransform>();
            gameobject.transform.SetParent(GameObject.Find("ActiveQuestPanelBackGroundLabel").transform, true);
            gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.width, GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height);
            gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height * tmpQuestActive);
            gameobject.AddComponent<Button>();
            gameobject.AddComponent<Text>();
            gameobject.GetComponent<Text>().text = QuestName;
            gameobject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            gameobject.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            gameobject.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            gameobject.GetComponent<Text>().fontStyle = FontStyle.Bold;
            gameobject.GetComponent<Text>().fontSize = (int)(gameobject.GetComponent<RectTransform>().rect.height / 2);
            gameobject.GetComponent<Text>().color = Color.black;
            gameobject.GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
                                                                                        _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestDescription,
                                                                                        _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestStep));
        }
        else
        {
            GameObject gameobject = new GameObject(QuestName);
            gameobject.AddComponent<RectTransform>();
            gameobject.transform.SetParent(GameObject.Find("FinishedQuestPanelBackGroundLabel").transform, true);
            gameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.width, GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height);
            gameobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height * tmpQuestFinished);
            gameobject.AddComponent<Button>();
            gameobject.AddComponent<Text>();
            gameobject.GetComponent<Text>().text = QuestName;
            gameobject.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            gameobject.GetComponent<Text>().font = _userInterface.GetComponent<Monitoring>().GetArialTextFont;
            gameobject.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            gameobject.GetComponent<Text>().fontStyle = FontStyle.Bold;
            gameobject.GetComponent<Text>().fontSize = (int)(gameobject.GetComponent<RectTransform>().rect.height / 2);
            gameobject.GetComponent<Text>().color = Color.black;
            gameobject.GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
                                                                                        _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestDescription,
                                                                                        _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestStep));
            
        }
    }
}
