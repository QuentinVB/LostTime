using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStateWayPoints : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if(GameObject.Find("PanelOverWriteData") == false)
        {
            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("PanelOverWriteData", GameObject.Find("Canvas"), true,
            GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 4, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2,
            0, 0, Color.white);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabel", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3, 0,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6,
                "Save your data ?", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelYes", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3,
                -GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
                -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6),
                "Yes", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
            GameObject.Find("PanelOverWriteDataLabelYes").AddComponent<Button>();
            GameObject.Find("PanelOverWriteDataLabelYes").GetComponent<Button>().onClick.AddListener(() => SaveGame());

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelNo", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
                -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6),
                "No", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
            GameObject.Find("PanelOverWriteDataLabelNo").AddComponent<Button>();
            GameObject.Find("PanelOverWriteDataLabelNo").GetComponent<Button>().onClick.AddListener(() => ClosePanel());
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Destroy(GameObject.Find("PanelOverWriteData"));
    }



    private void SaveGame()
    {
        Debug.Log("Save");
        GameObject.Find("Canvas").GetComponent<SavePlayerPosition>().SaveCurrentGameConfig("LostTimeGearDistrict");
        Destroy(GameObject.Find("PanelOverWriteData"));
    }

    private void ClosePanel()
    {
        Destroy(GameObject.Find("PanelOverWriteData"));
    }
}
