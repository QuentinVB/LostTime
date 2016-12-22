using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameTittle : MonoBehaviour {

    public Image _gameTittle;
    public Image _backGroundMenuGame;

    void Start () {
        //_gameTittle = transform.FindChild("GameTittle").GetComponent<Image>();
        //_backGroundMenuGame = transform.FindChild("BackGroundMenuGame").GetComponent<Image>();
        _gameTittle.rectTransform.sizeDelta = _backGroundMenuGame.rectTransform.sizeDelta / 3;

    }
}
