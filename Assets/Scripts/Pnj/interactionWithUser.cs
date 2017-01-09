using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

interface IinteractionWithUser
{
    //     interactionWithUser InstantiateIinteractionWithUser();
}

public class interactionWithUser : MonoBehaviour, IinteractionWithUser
{
    private Text display;
    void Start()
    {
        display = GameObject.Find("TextFieldTest").GetComponent<Text>();
        display.text = "test test";
    }

    public Text getDisplay()
    {
        return display;
    }

}
