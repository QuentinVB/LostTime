using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitoring : MonoBehaviour {

    private List<string> _gameLanguages;
    private string _CurrentGameLanguages;

    private void Start()
    {
        if(PlayerPrefs.GetInt("ShadowIsActivatedSave") == 0)
        {
            GameObject.Find("Sun").GetComponent<Light>().shadows = LightShadows.None;
        }
        else
        {
            GameObject.Find("Sun").GetComponent<Light>().shadows = LightShadows.Soft;
        }

        _CurrentGameLanguages = "English";
    }
    public void CreateGameLanguagesList()
    {
        if(_CurrentGameLanguages == "Anglais" || _CurrentGameLanguages == "English")
        {
            _CurrentGameLanguages = "English";

            _gameLanguages = new List<string>();
            _gameLanguages.Add("French");
            _gameLanguages.Add("English");
        }
        if(_CurrentGameLanguages == "Français" || _CurrentGameLanguages == "French")
        {
            _CurrentGameLanguages = "Français";

            _gameLanguages = new List<string>();
            _gameLanguages.Add("Français");
            _gameLanguages.Add("Anglais");
        }
    }

    public List<string> GetGameLanguaguesList
    {
        get { return _gameLanguages; }
    }
    
}
