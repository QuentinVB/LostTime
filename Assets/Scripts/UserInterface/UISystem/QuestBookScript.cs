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

    private bool _isActivedQuestBookPanelActivated;

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

            _userInterface.GetComponent<ImageMonitoring>().PutBackGroundImageOnGameObject("QuestBookPanelTexture", "QuestBookPanel", _userInterface.GetComponent<ImageMonitoring>().GetBackGround5,
                false, _userInterface.GetComponent<ImageMonitoring>().GetBackGround5, false, _userInterface.GetComponent<ImageMonitoring>().GetBackGround5,
                false, _userInterface.GetComponent<ImageMonitoring>().GetBackGround5, false, _userInterface.GetComponent<ImageMonitoring>().GetBackGround5, 0, 0);

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
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("QuestBookLabel", GameObject.Find("QuestBookPanel"), true,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width, GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 5,
            0, GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 10,
            "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 15)), Color.black);
        _userInterface.GetComponent<TextMonitoring>().setTextInCorrectLanguages("QuestBookLabel", "QuestBook", "Livre des quêtes");

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("QuestBookBackGround", GameObject.Find("QuestBookPanel"), true,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 15,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height/ 10, 0,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 2 -
            GameObject.Find("QuestBookLabel").GetComponent<RectTransform>().rect.height - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 20, Color.clear);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("ButtonActiveQuestPanelBackGround", GameObject.Find("QuestBookBackGround"), true,
            GameObject.Find("QuestBookBackGround").GetComponent<RectTransform>().rect.width / 2,
            GameObject.Find("QuestBookBackGround").GetComponent<RectTransform>().rect.height,
            GameObject.Find("QuestBookBackGround").GetComponent<RectTransform>().rect.width / -4, 0,
            _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ButtonActiveQuestPanel", GameObject.Find("ButtonActiveQuestPanelBackGround"), true,
            GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<RectTransform>().rect.height,
            0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 15)), Color.black);
        _userInterface.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ButtonActiveQuestPanel", "Active Quest", "Quêtes Actif");
        GameObject.Find("ButtonActiveQuestPanel").AddComponent<Button>();
        GameObject.Find("ButtonActiveQuestPanel").GetComponent<Button>().onClick.AddListener(() => ShowActiveQuest());

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("ButtonFinishedQuestPanelBackGround", GameObject.Find("QuestBookBackGround"), true,
            GameObject.Find("QuestBookBackGround").GetComponent<RectTransform>().rect.width / 2,
            GameObject.Find("QuestBookBackGround").GetComponent<RectTransform>().rect.height,
            GameObject.Find("QuestBookBackGround").GetComponent<RectTransform>().rect.width / 4, 0,
            _userInterface.GetComponent<ImageMonitoring>().GetInventoryBagBackGround);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ButtonFinishedQuestPanel", GameObject.Find("ButtonFinishedQuestPanelBackGround"), true,
            GameObject.Find("ButtonFinishedQuestPanelBackGround").GetComponent<RectTransform>().rect.width, GameObject.Find("ButtonFinishedQuestPanelBackGround").GetComponent<RectTransform>().rect.height,
            0, 0, "", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 15)), Color.black);
        _userInterface.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ButtonFinishedQuestPanel", "Quest ended", "Quêtes Finis");
        GameObject.Find("ButtonFinishedQuestPanel").AddComponent<Button>();
        GameObject.Find("ButtonFinishedQuestPanel").GetComponent<Button>().onClick.AddListener(() => ShowEndedQuest());

        ShowActiveQuest();
    }


    private void ShowActiveQuest()
    {
        if (GameObject.Find("QuestBookBackGroundEndedQuest") == true)
        {
            Destroy(GameObject.Find("QuestBookBackGroundEndedQuest"));
        }

        if (_isActivedQuestBookPanelActivated == false)
        {
            setColorOnButton();

            _isActivedQuestBookPanelActivated = true;

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("QuestBookBackGroundActiveQuest", GameObject.Find("QuestBookPanel"), true,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 15,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height
            - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 15f
            - GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<RectTransform>().rect.height
             - GameObject.Find("QuestBookLabel").GetComponent<RectTransform>().rect.height, 0,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height
            - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 7.5f
            - GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<RectTransform>().rect.height
             - GameObject.Find("QuestBookLabel").GetComponent<RectTransform>().rect.height) / -4, Color.clear);

            float tmpActiveQuest = 1;

            for (int var = 0; var < _userInterface.GetComponent<QuestBook>().GetQuestBook.Count; var++)
            {
                if (_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestIsFinished == false)
                {
                    ShowActiveQuestList(var, tmpActiveQuest);
                    tmpActiveQuest++;
                }
            }
            
        }
    }

    private void ShowEndedQuest()
    {
        if (GameObject.Find("QuestBookBackGroundActiveQuest") == true)
        {
            Destroy(GameObject.Find("QuestBookBackGroundActiveQuest"));
        }

        if (_isActivedQuestBookPanelActivated == true)
        {
            setColorOnButton();

            _isActivedQuestBookPanelActivated = false;

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("QuestBookBackGroundEndedQuest", GameObject.Find("QuestBookPanel"), true,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 15,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height
            - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 15f
            - GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<RectTransform>().rect.height
             - GameObject.Find("QuestBookLabel").GetComponent<RectTransform>().rect.height, 0,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height
            - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 7.5f
            - GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<RectTransform>().rect.height
             - GameObject.Find("QuestBookLabel").GetComponent<RectTransform>().rect.height) / -4, Color.clear);

            float tmpFinishedQuest = 1;

            for (int var = 0; var < _userInterface.GetComponent<QuestBook>().GetQuestBook.Count; var++)
            {
                if (_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestIsFinished == true)
                {
                    ShowFinishedQuestList(var, tmpFinishedQuest);
                    tmpFinishedQuest++;
                }

            }
            
        }
        
    }

    private void ShowActiveQuestList(int var, float tmpActiveQuest)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround",
            GameObject.Find("QuestBookBackGroundActiveQuest"), true,
            GameObject.Find("QuestBookBackGroundActiveQuest").GetComponent<RectTransform>().rect.width,
            GameObject.Find("QuestBookBackGroundActiveQuest").GetComponent<RectTransform>().rect.height / 15,
            0, GameObject.Find("QuestBookBackGroundActiveQuest").GetComponent<RectTransform>().rect.height / 2
            - ((GameObject.Find("QuestBookBackGroundActiveQuest").GetComponent<RectTransform>().rect.height / 15) * tmpActiveQuest), new Color(255, 255, 255, 0.5f));

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, 
            GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround"), true, 
            GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround").GetComponent<RectTransform>().rect.width, 
            GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround").GetComponent<RectTransform>().rect.height,
            0, 0, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleLeft, FontStyle.Bold, (int)(GameObject.Find("QuestBookBackGroundActiveQuest").GetComponent<RectTransform>().rect.height / 15), Color.black);
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).AddComponent<Button>();
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(
            _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestDescription));
    }

    private void ShowFinishedQuestList(int var, float tmpFinishedQuest)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround",
            GameObject.Find("QuestBookBackGroundEndedQuest"), true,
            GameObject.Find("QuestBookBackGroundEndedQuest").GetComponent<RectTransform>().rect.width,
            GameObject.Find("QuestBookBackGroundEndedQuest").GetComponent<RectTransform>().rect.height / 15,
            0, GameObject.Find("QuestBookBackGroundEndedQuest").GetComponent<RectTransform>().rect.height / 2
            - ((GameObject.Find("QuestBookBackGroundEndedQuest").GetComponent<RectTransform>().rect.height / 15) * tmpFinishedQuest), new Color(255, 255, 255, 0.5f));

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
            GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround"), true,
            GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround").GetComponent<RectTransform>().rect.width,
            GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName + "BackGround").GetComponent<RectTransform>().rect.height,
            0, 0, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleLeft, FontStyle.Bold, (int)(GameObject.Find("QuestBookBackGroundEndedQuest").GetComponent<RectTransform>().rect.height / 15), Color.black);
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).AddComponent<Button>();
        GameObject.Find(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName).GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(
            _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestDescription));
    }

    private void ShowQuestDetail(string QuestLabel, string QuestDescription)
    {
        if(GameObject.Find("QuestDetailBackGround") == false)
        {
            _lastQuestOpen = QuestLabel;
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("QuestDetailBackGround", GameObject.Find("QuestBookPanel"), true,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 3,
            GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height,
            (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 2) - (GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 6),
            0, _userInterface.GetComponent<ImageMonitoring>().GetBackGround5);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("QuestDetailLabel", GameObject.Find("QuestDetailBackGround"), true,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.width,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 10,
                0, GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 10, 
                QuestLabel, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                (int)(GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 20f), Color.black);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("QuestDetailDescription", GameObject.Find("QuestDetailBackGround"), true,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.width,
                GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height - GameObject.Find("QuestDetailLabel").GetComponent<RectTransform>().rect.height,
                0, GameObject.Find("QuestDetailLabel").GetComponent<RectTransform>().rect.height / 2, QuestDescription, _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                (int)(GameObject.Find("QuestDetailBackGround").GetComponent<RectTransform>().rect.height / 20f), Color.black);

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

    private void setColorOnButton()
    {
        if(_isActivedQuestBookPanelActivated == true)
        {
            GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GameObject.Find("ButtonActiveQuestPanel").GetComponent<Text>().color = new Color(0, 0, 0, 0.5f);

            GameObject.Find("ButtonFinishedQuestPanelBackGround").GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            GameObject.Find("ButtonFinishedQuestPanel").GetComponent<Text>().color = new Color(0, 0, 0, 1f);
        }
        else
        {
            GameObject.Find("ButtonFinishedQuestPanelBackGround").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GameObject.Find("ButtonFinishedQuestPanel").GetComponent<Text>().color = new Color(0, 0, 0, 0.5f);

            GameObject.Find("ButtonActiveQuestPanelBackGround").GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            GameObject.Find("ButtonActiveQuestPanel").GetComponent<Text>().color = new Color(0, 0, 0, 1f);
        }
    }
}
