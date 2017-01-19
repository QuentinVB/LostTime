using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeavePanelScript : MonoBehaviour, IPointerDownHandler
{
    private bool _closeGameMapPanel;
    private bool _closeQuestBookPanel;
    private bool _closeSystemConfigurationPanel;

    private void Update()
    {
        if(_closeGameMapPanel == true)
        {
            _closeGameMapPanel = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("GameMapPanel",
               GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("GameMapPanel").GetComponent<RectTransform>().rect.height / 2, 1);
        }

        if(_closeQuestBookPanel == true)
        {
            _closeQuestBookPanel = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("QuestBookPanel",
                GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("QuestBookPanel").GetComponent<RectTransform>().rect.height / 2, 1);
        }

        if(_closeSystemConfigurationPanel == true)
        {
            _closeSystemConfigurationPanel = GameObject.Find("Canvas").GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("SystemConfigurationPanel",
                (GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 + GameObject.Find("SystemConfigurationPanel").GetComponent<RectTransform>().rect.height / 2), 1);
        }
       
    }

    public virtual void OnPointerDown(PointerEventData evt)
    {
        if(GameObject.Find("GameMapPanel") == true)
        {
            _closeGameMapPanel = true;
        }

        if(GameObject.Find("QuestBookPanel") == true)
        {
            _closeQuestBookPanel = true;
        }

        if(GameObject.Find("SystemConfigurationPanel") == true)
        {
            _closeSystemConfigurationPanel = true;
        }
    }
}
