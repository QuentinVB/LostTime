using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPosition : MonoBehaviour {
    
    public void SaveCurrentGameConfig(string CurrentScene)
    {
        if(PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
            PlayerPrefs.SetFloat("SaveStateOneAstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
            PlayerPrefs.SetFloat("SaveStateOneAstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
            PlayerPrefs.SetFloat("SaveStateOneAstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
            // PlayerPrefs.SetInt("SaveStateOneFragments", );
            // PlayerPrefs.SetInt("SaveStateOneCycle", );
            // PlayerPrefs.SetFloat("SaveStateOneTimer", );
            PlayerPrefs.SetString("SaveStateOneCurrentScene", CurrentScene);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
            PlayerPrefs.SetFloat("SaveStateTwoAstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
            PlayerPrefs.SetFloat("SaveStateTwoAstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
            PlayerPrefs.SetFloat("SaveStateTwoAstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
            // PlayerPrefs.SetInt("SaveStateOneFragments", );
            // PlayerPrefs.SetInt("SaveStateOneCycle", );
            // PlayerPrefs.SetFloat("SaveStateOneTimer", );
            PlayerPrefs.SetString("SaveStateTwoCurrentScene", CurrentScene);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            PlayerPrefs.SetFloat("SaveStateThreeAstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
            PlayerPrefs.SetFloat("SaveStateThreeAstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
            PlayerPrefs.SetFloat("SaveStateThreeAstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
            PlayerPrefs.SetFloat("SaveStateThreeAstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
            PlayerPrefs.SetFloat("SaveStateThreeAstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
            PlayerPrefs.SetFloat("SaveStateThreeAstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
            // PlayerPrefs.SetInt("SaveStateOneFragments", );
            // PlayerPrefs.SetInt("SaveStateOneCycle", );
            // PlayerPrefs.SetFloat("SaveStateOneTimer", );
            PlayerPrefs.SetString("SaveStateThreeCurrentScene", CurrentScene);
        }
    }


}
