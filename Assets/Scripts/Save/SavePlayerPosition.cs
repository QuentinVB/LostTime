using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPosition : MonoBehaviour {

    private bool _saveStateOneUsed;
    private bool _saveStateTwoUsed;
    private bool _saveStateThreeUsed;

    public void SavePlayerNewPosition(Vector3 PlayerPosition)
    {
        PlayerPrefs.SetFloat("PlayerPositionX", PlayerPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", PlayerPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", PlayerPosition.z);
    }

    public void SaveStateOneMenu(int used)
    {
        PlayerPrefs.SetInt("SaveStateOne", used);
    }

    public void SaveStateTwoMenu(int used)
    {
        PlayerPrefs.SetInt("SaveStateTwo", used);
    }

    public void SaveStateThreeMenu(int used)
    {
        PlayerPrefs.SetInt("SaveStateThree", used);
    }

    public bool SaveStateOneUsed
    {
        get { return _saveStateOneUsed; }
    }

    public bool SaveStateTwoUsed
    {
        get { return _saveStateTwoUsed; }
    }

    public bool SaveStateThreeUsed
    {
        get { return _saveStateThreeUsed; }
    }

    public Vector3 GetPlayerPosition
    {
        get { return new Vector3(PlayerPrefs.GetFloat("PlayerPositionX"), PlayerPrefs.GetFloat("PlayerPositionY"), PlayerPrefs.GetFloat("PlayerPositionZ")); }
    }
}
