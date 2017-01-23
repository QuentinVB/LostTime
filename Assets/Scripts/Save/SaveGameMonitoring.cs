using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameMonitoring : MonoBehaviour
{

    public string GetGameLanguages
    {
        get { return PlayerPrefs.GetString("CurrentLanguagesUsed"); }
    }

    public float GetSoundTrackVolume
    {
        get { return PlayerPrefs.GetFloat("SoundTrackVolumeSave"); }
    }

    public float GetSoundEffectVolume
    {
        get { return PlayerPrefs.GetFloat("SoundEffectVolumeSave"); }
    }

}
