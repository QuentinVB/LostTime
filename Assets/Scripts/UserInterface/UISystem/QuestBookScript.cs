using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestBookScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _userInterface;

    private void Start()
    {
        _userInterface = GameObject.Find("Canvas");
    }

    public virtual void OnPointerDown(PointerEventData Map)
    {
        if (GameObject.Find("SystemConfigurationPanel") == true)
            Destroy(GameObject.Find("SystemConfigurationPanel"));

        if (GameObject.Find("GameMapPanel") == true)
            Destroy(GameObject.Find("GameMapPanel"));

        if (GameObject.Find("InventoryBag") == true)
            Destroy(GameObject.Find("InventoryBag"));

        if (GameObject.Find("QuestBookPanel") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("QuestBookPanel", GameObject.Find("Canvas"), true,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 2,
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height,
                0, 0, Color.grey);
            GameObject.Find("QuestBookPanel").transform.SetParent(GameObject.Find("SystemPanel").transform, true);

            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("ButtonLeaveQuest", GameObject.Find("QuestBookPanel"), true,
                GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 15,
                GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 15,
                GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 2 - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 30,
                GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.width / 30, Color.red);
            GameObject.Find("ButtonLeaveQuest").AddComponent<LeavePanelScript>();

            ShowQuestBook();
        }
        else
        {
            Destroy(GameObject.Find("QuestBookPanel"));
        }

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
    }

    private void ShowFinishedQuestList(int var, float tmpFinishedQuest)
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(_userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName, GameObject.Find("FinishedQuestPanelBackGroundLabel"), true,
            GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.width, GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height,
            0, -GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height * tmpFinishedQuest, _userInterface.GetComponent<QuestBook>().GetQuestBook[var].GetQuestName,
            _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.UpperCenter, FontStyle.Bold, (int)(GameObject.Find("FinishedQuestPanelBackGroundLabel").GetComponent<RectTransform>().rect.height / 2), Color.black);
    }

    private void ShowQuestDetail()
    {

    }
}
