using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLoadSceneWayPoints : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
        if (PlayerPrefs.GetString("CurrentScene") == "LostTimeGearDistrict")
        {
            createWayPoints("LostTimeMenuGame", 16f, 2.5f, 29.7f);
        }
        
    }


    
    private void createWayPoints(string GameObjectName, float PosX, float PosY, float PosZ)
    {

        if (GameObject.Find(GameObjectName) == false)
        {
            GameObject gameObject = new GameObject(GameObjectName);
            gameObject.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObject.AddComponent<BoxCollider>();
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 5f, 1f);
            gameObject.AddComponent<NewSceneWayPointsController>();

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
        }
    }
}


