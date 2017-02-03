using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLoadSceneWayPoints : MonoBehaviour {
    



    private bool _isCollisionTrue;
    private float _NewSceneAstridPositionX;
    private float _NewSceneAstridPositionY;
    private float _NewSceneAstridPositionZ;

    void Start ()
    {
        
        if (PlayerPrefs.GetString("CurrentScene") == "LostTimeGearDistrict")
        {
            if(GameObject.Find("LostTimeAstridHouse") == false)
            {
                createWayPoints("LostTimeAstridHouse", 16f, 2.5f, 29.7f, -1.8f, 1.5f, 5.15f);
            }
            
        }
        if(PlayerPrefs.GetString("CurrentScene") == "LostTimeAstridHouse")
        {
            if (GameObject.Find("LostTimeGearDistrict") == false)
            {
                createWayPoints("LostTimeGearDistrict", -1.8f, 2.5f, 5.15f, 16f, 2.5f, 29.7f);
            }
                
        }
        
    }


    
    private void createWayPoints(string GameObjectName, float PosX, float PosY, float PosZ, float x, float y, float z)
    {

        if (GameObject.Find(GameObjectName) == false)
        {
            GameObject gameObject = new GameObject(GameObjectName);
            gameObject.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObject.AddComponent<BoxCollider>();
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 5f, 1f);
            gameObject.AddComponent<CreateLoadSceneWayPoints>();

            GameObject gameObjectAnimation = new GameObject(GameObjectName + "GearAnimation");
            gameObjectAnimation.transform.SetParent(GameObject.Find(GameObjectName).transform, true);
            gameObjectAnimation.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObjectAnimation.AddComponent<SaveStateAnimation>();

            GameObject gameObjectGearSprite = new GameObject(GameObjectName + "GearSprite");
            gameObjectGearSprite.transform.tag = "SaveStateWayPointGearSprite";
            gameObjectGearSprite.transform.SetParent(GameObject.Find(GameObjectName + "GearAnimation").transform, true);
            gameObjectGearSprite.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObjectGearSprite.AddComponent<SpriteRenderer>();
            gameObjectGearSprite.GetComponent<SpriteRenderer>().sprite = GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetLeaveButton;
            //gameObjectGearSprite.AddComponent<SaveStateSpriteAnimation>();
            _NewSceneAstridPositionX = x;
            _NewSceneAstridPositionY = y;
            _NewSceneAstridPositionZ = z;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _isCollisionTrue = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_isCollisionTrue == true)
        {
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _isCollisionTrue = false;
        }
    }
    private void OnMouseDown()
    {
        if (GameObject.Find("PanelOverWriteData") == false && _isCollisionTrue == true && GameObject.Find("InventoryBag") == false && GameObject.Find("GameMapPanel") == false
            && GameObject.Find("QuestBookPanel") == false && GameObject.Find("SystemConfigurationPanel") == false)
        {
            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("PanelOverWriteData", GameObject.Find("Canvas"), true,
            GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / 6, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 4,
            0, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 8, GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetBackGround5);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabel", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2, 0,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4,
                "Changer de Scène", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);

            GameObject.Find("Canvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelYes", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2,
                -GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
                -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4),
                "Yes", GameObject.Find("Canvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
            GameObject.Find("PanelOverWriteDataLabelYes").AddComponent<Button>();
            GameObject.Find("PanelOverWriteDataLabelYes").GetComponent<Button>().onClick.AddListener(() => LoadNewScene());

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

    private void LoadNewScene()
    {
        GameObject.Find("Canvas").GetComponent<SaveController>().LoadSceneAstridPosition(_NewSceneAstridPositionX, _NewSceneAstridPositionY, _NewSceneAstridPositionZ, this.gameObject.name);

        Destroy(GameObject.Find("PanelOverWriteData"));
    }

    private void ClosePanel()
    {
        Destroy(GameObject.Find("PanelOverWriteData"));
    }
}


