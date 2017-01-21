using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPosition : MonoBehaviour {

    private int _isSaveStateOneUsed; //bool
    private int _isSaveStateTwoUsed; //bool
    private int _isSaveStateThreeUsed; //bool
    private string _currentSaveStateUsed;

    private int _SoundTrackVolume;
    private int _SoundEffectsVolume;

    private string _gameLanguageChoose;

    public void LoadMenuConfig()
    {

    }

    public void LoadGameConfig()
    {
    }

    public void SaveCurrentGameConfig()
    {

    }

    public int IsSaveStateOneUsed
    {
        get { return _isSaveStateOneUsed; }
    }

    public int IsSaveStateTwoUsed
    {
        get { return _isSaveStateTwoUsed; }
    }

    public int IsSaveStateThreeUsed
    {
        get { return _isSaveStateThreeUsed; }
    }

    public int GetSoundTrackVolume
    {
        get { return _SoundTrackVolume; }
    }

    public int GetSoundEffectVolume
    {
        get { return _SoundEffectsVolume; }
    }

    public string GetGameLanguages
    {
        get { return _gameLanguageChoose; }
    }


}
