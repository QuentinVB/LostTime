using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStateController : MonoBehaviour {

    private void Start()
    {
        /*if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            if(PlayerPrefs.GetString("SaveStateOneCurrentScene") == "LostTimeGearDistrict")
            {
                CreateLostTimeGearDiscritSaveStateWayPoints();
            }
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            if (PlayerPrefs.GetString("SaveStateTwoCurrentScene") == "LostTimeGearDistrict")
            {
                CreateLostTimeGearDiscritSaveStateWayPoints();
            }
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            if (PlayerPrefs.GetString("SaveStateThreeCurrentScene") == "LostTimeGearDistrict")
            {
                CreateLostTimeGearDiscritSaveStateWayPoints();
            }
        }*/
    }

    private void Update()
    {
        GameObject.Find("Chunk-Market-GearAnimation").transform.Rotate(0, 0, GameObject.Find("Chunk-Market-GearAnimation").transform.rotation.z + 1f);
        GameObject.Find("Chunk-Garden-GearAnimation").transform.Rotate(0, 0, GameObject.Find("Chunk-Garden-GearAnimation").transform.rotation.z + 1f);
        GameObject.Find("Chunk-SouthStreet-GearAnimation").transform.Rotate(0, 0, GameObject.Find("Chunk-SouthStreet-GearAnimation").transform.rotation.z + 1f);

        GameObject.Find("Chunk-Market-GearSprite").transform.Rotate(0, 0, GameObject.Find("Chunk-Market-GearSprite").transform.rotation.z + 1f);
        GameObject.Find("Chunk-Garden-GearSprite").transform.Rotate(0, 0, GameObject.Find("Chunk-Garden-GearSprite").transform.rotation.z + 1f);
        GameObject.Find("Chunk-SouthStreet-GearSprite").transform.Rotate(0, 0, GameObject.Find("Chunk-SouthStreet-GearSprite").transform.rotation.z + 1f);
    }
}
