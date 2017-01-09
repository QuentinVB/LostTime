using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitoring : MonoBehaviour {

    public Sprite _mapButton;
    public Sprite _ConfigButton;
    public Sprite _QuestButton;
    public Sprite _LeaveButton;
    public Sprite _MapPanel;
    public Sprite _BagButton;
    public Sprite _DownArrow;
    public Sprite _knob;

    public Font _ArialTextFont;

    private List<string> _gameLanguages;
    private string _CurrentGameLanguages;

    private void Start()
    {
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

    public string GetCurrentGameLanguages
    {
        get { return _CurrentGameLanguages; }
        set { _CurrentGameLanguages = value; }
    }

    public List<string> GetGameLanguaguesList
    {
        get { return _gameLanguages; }
    }
    public Font GetArialTextFont
    {
        get { return _ArialTextFont; }
    }

    public Sprite GetKnob
    {
        get { return _knob; }
    }

    public Sprite DownArrow
    {
        get { return _DownArrow; }
    }

    public Sprite MapButton
    {
        get { return _mapButton; }
    }

    public Sprite ConfigButton
    {
        get { return _ConfigButton; }
    }

    public Sprite QuestButton
    {
        get { return _QuestButton; }
    }

    public Sprite LeaveButton
    {
        get { return _LeaveButton; }
    }

    public Sprite MapPanel
    {
        get { return _MapPanel; }
    }

    public Sprite BagButton
    {
        get { return _BagButton; }
    }
}
