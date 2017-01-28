using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStateWayPoints : MonoBehaviour {

    private bool _onCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            _onCollision = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _onCollision = true;
        }
    }

    private void OnMouseDown()
    {
        if (GameObject.Find("PanelOverWriteData") == false && _onCollision == true && GameObject.Find("InventoryBag") == false && GameObject.Find("GameMapPanel") == false 
            && GameObject.Find("QuestBookPanel") == false && GameObject.Find("SystemConfigurationPanel") == false)
        {
            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("PanelOverWriteData", GameObject.Find("Canvas"), true,
            GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 6, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 4,
            0, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 8, Color.white);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabel", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2, 0,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4,
                "Save your data ?", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelYes", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2,
                -GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
                -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4),
                "Yes", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
            GameObject.Find("PanelOverWriteDataLabelYes").AddComponent<Button>();
            GameObject.Find("PanelOverWriteDataLabelYes").GetComponent<Button>().onClick.AddListener(() => SaveGame());

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelNo", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
                -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4),
                "No", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
            GameObject.Find("PanelOverWriteDataLabelNo").AddComponent<Button>();
            GameObject.Find("PanelOverWriteDataLabelNo").GetComponent<Button>().onClick.AddListener(() => ClosePanel());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag =="Player")
        {
            _onCollision = false;
            Destroy(GameObject.Find("PanelOverWriteData"));
        }
        
    }



    private void SaveGame()
    {
        Debug.Log("Save");
        GameObject.Find("Canvas").GetComponent<SaveController>().SaveCurrentGameConfig("LostTimeGearDistrict");
        Destroy(GameObject.Find("PanelOverWriteData"));
    }

    private void ClosePanel()
    {
        Destroy(GameObject.Find("PanelOverWriteData"));
    }
}
