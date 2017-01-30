using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestBookScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _userInterface;
    private string _lastQuestOpen;

    private bool _isBookQuestOpen;
    private bool _isDetailQuestOpen;
    private bool _isQuestBookAnimationOn;
    private bool _isDestailQuestAnimationOn;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
    }

    private void Update()
    {
        #region PanelQuestBookAnimationController

        if (GameObject.Find("QuestBookPanel") == true && _isBookQuestOpen == true && _isQuestBookAnimationOn == true)
        {
            _isQuestBookAnimationOn = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("QuestBookPanel",
                0, 0, -1);
        }
        else if (GameObject.Find("QuestBookPanel") == true && _isBookQuestOpen == false && _isQuestBookAnimationOn == true)
        {
            _isQuestBookAnimationOn = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("QuestBookPanel",
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 2, 1);
        }
        #endregion

        #region PanelDescriptionQuestAnimationController

        if (GameObject.Find("QuestDetailBackGround") == true && _isDetailQuestOpen == true && _isDestailQuestAnimationOn == true)
        {
            _isDestailQuestAnimationOn = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceLeftToRight("QuestDetailBackGround",
                (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 2) +
                    (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 6), 0, 1);
        }
        else if (GameObject.Find("QuestDetailBackGround") == true && _isDetailQuestOpen == false && _isDestailQuestAnimationOn == true)
        {
            _isDestailQuestAnimationOn = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyRightToLeft("QuestDetailBackGround",
                (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 6),
                -1);
        } 
        #endregion
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("SystemConfigurationPanel") == true)
        {
            GameObject.Find("SystemConfiguration").GetComponent<SystemConfigurationScript>().DestroyPanel();
        }

        if (GameObject.Find("GameMapPanel") == true)
        {
            GameObject.Find("GameMap").GetComponent<GameMapScript>().DestroyPanel();
        }

        if (GameObject.Find("InventoryBag") == true)
        {
            GameObject.Find("ButtonInventory").GetComponent<InventoryScript>().DestroyPanel();
        }

        if (GameObject.Find("QuestBookPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("QuestBookPanel", GameObject.Find("Canvas"), true,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height,
                0, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height + GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2, Color.grey);

            _userInterface.GetComponent<ImageMonitoring>().PutBackGroundImageOnGameObject("QuestBookPanelTexture", "QuestBookPanel", _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround,
                false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround, false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround,
                false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround, false, _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround, 0, 0);

            //_userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("ButtonLeaveQuest", GameObject.Find("QuestBookPanel"), true,
            //    GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 15,
            //    GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 15,
            //    GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 2 - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 30,
            //    GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 30, Color.red);
            //GameObject.Find("ButtonLeaveQuest").AddComponent<Button>();
            //GameObject.Find("ButtonLeaveQuest").GetComponent<Button>().onClick.AddListener(() => DestroyPanel());

            _isBookQuestOpen = true;
            _isQuestBookAnimationOn = true;

            ShowQuestBook();
        }
        else
        {
            _isBookQuestOpen = false;   
            _isQuestBookAnimationOn = true;
        }

    }

    public void DestroyPanel()
    {
        _isBookQuestOpen = false;
        _isQuestBookAnimationOn = true;
    }

    private void ShowQuestBook()
    {
        CreateActiveQuestPanel(-2.5f, -1f, "ActiveQuestPanelBackGround", "ActiveQuest");
        CreateActiveQuestPanel(2.5f, -1f, "FinishedQuestPanelBackGround", "FinishedQuest");

        ShowQuest();
    }

    private void CreateActiveQuestPanel(float PanelBackGroundX, float PanlBachGroundY, string PanelName, string Label)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(PanelName, GameObject.Find("QuestBookPanel"), true,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 10) * 4,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 10) * 8,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 10) * PanelBackGroundX,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 10) * PanlBachGroundY,
            Color.white);
        
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(PanelName + "Label", GameObject.Find(PanelName), true,
            GameObject.Find(PanelName).GetComponent<RectTransform>().rect.width,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 10,
            0, (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 10) * 3.5f,
            Label, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter, FontStyle.Bold,
            (int)(GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 20), Color.black);
    }

    private void ShowQuest()
    {
        float tmpActiveQuest = 1;
        float tmpFinishedQuest = 1;

        for (int var = 0; var < _userInterface.GetComponent<QuestBook>().GetQuestBook.Count; var++)
        {
            if (_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestIsFinished == false)
            {
                ShowActiveQuestList(var, tmpActiveQuest);
                tmpActiveQuest++;
            }
            else
            {
                ShowFinishedQuestList(var, tmpFinishedQuest);
                tmpFinishedQuest++;
            }

        }
    }

    private void ShowActiveQuestList(int var, float tmpActiveQuest)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, GameObject.Find("ActiveQuestPanelBackGroundLabel"), true,
            GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.width, GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height,
            0, -GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height * tmpActiveQuest, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter, FontStyle.Bold, (int)(GameObject.Find("ActiveQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height / 2), Color.black);
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).AddComponent<Button>();
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(
            _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestDescription));
    }

    private void ShowFinishedQuestList(int var, float tmpFinishedQuest)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, GameObject.Find("FinishedQuestPanelBackGroundLabel"), true,
            GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.width, GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height,
            0, -GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height * tmpFinishedQuest, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter, FontStyle.Bold, (int)(GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height / 2), Color.black);
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).AddComponent<Button>();
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(
            _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestDescription));
    }

    private void ShowQuestDetail(string QuestLabel, string QuestDescription)
    {
        if(GameObject.Find("QuestDetailBackGround") == false)
        {
            _lastQuestOpen = QuestLabel;
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("QuestDetailBackGround", GameObject.Find("QuestBookPanel"), true,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 3,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 6),
            0, Color.white);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("QuestDetailLabel", GameObject.Find("QuestDetailBackGround"), true,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.width,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height,
                0, 0, QuestLabel, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter, FontStyle.Bold,
                (int)(GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 15f), Color.black);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("QuestDetailDescription", GameObject.Find("QuestDetailBackGround"), true,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.width,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height,
                0, 0, QuestDescription, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                (int)(GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 15f), Color.black);

            _isDetailQuestOpen = true;
            _isDestailQuestAnimationOn = true;
        }
        else
        {
            if(_lastQuestOpen != QuestLabel)
            {
                _lastQuestOpen = QuestLabel;
                GameObject.Find("QuestDetailLabel").GetComponent<Text>().text = QuestLabel;
                GameObject.Find("QuestDetailDescription").GetComponent<Text>().text = QuestDescription;
            }
            else
            {
                _isDetailQuestOpen = false;
                _isDestailQuestAnimationOn = true;
            }
        }
        
    }
}
