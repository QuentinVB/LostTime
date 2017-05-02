using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStateController : MonoBehaviour {

    private void Start()
    {
        SetWayPointsOnMap();
    }
    

    private void SetWayPointsOnMap()
    {
            if (PlayerPrefs.GetString("CurrentScene") == "LostTimeGearDistrict")
            {
                createWayPoints("ChunkGardenSave", -16f, 3f, -51f);
                createWayPoints("ChunkSouthStreetSave", 15f, 3f, 54f);
                createWayPoints("ChunkMarketSave", 12.5f, 2f, -3f);
            }
        
    }

    private void createWayPoints(string GameObjectName, float PosX, float PosY, float PosZ)
    {

        if(GameObject.Find(GameObjectName + "WayPoints") ==  false)
        {
            GameObject gameObject = new GameObject(GameObjectName + "WayPoints");
            gameObject.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObject.AddComponent<BoxCollider>();
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 5f, 1f);
            gameObject.AddComponent<SaveStateWayPoints>();

            GameObject gameObjectAnimation = new GameObject(GameObjectName + "GearAnimation");
            gameObjectAnimation.transform.SetParent(GameObject.Find(GameObjectName + "WayPoints").transform, true);
            gameObjectAnimation.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObjectAnimation.AddComponent<SaveStateAnimation>();

            GameObject gameObjectGearSprite = new GameObject(GameObjectName + "GearSprite");
            gameObjectGearSprite.transform.tag = "SaveStateWayPointGearSprite";
            gameObjectGearSprite.transform.SetParent(GameObject.Find(GameObjectName + "GearAnimation").transform, true);
            gameObjectGearSprite.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObjectGearSprite.AddComponent<SpriteRenderer>();
            gameObjectGearSprite.GetComponent<SpriteRenderer>().sprite = GameObject.Find("Canvas").GetComponent<ImageMonitoring>().GetYellowGear;
            gameObjectGearSprite.AddComponent<SaveStateSpriteAnimation>();
        }
    }
}
