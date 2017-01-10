using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

interface IinteractionWithUser
{
    Text getDisplay();
    void setDisplay(string text);
}

public class interactionWithUser : MonoBehaviour, IinteractionWithUser
{
    private Text display;
    void Start()
    {
        display = GameObject.Find("TextFieldTest").GetComponent<Text>();
        display.text = "Iteration 2 : Test";
    }

    public Text getDisplay()
    {
        return display;
    }

    public void setDisplay(string text)
    {
        display.text = text;
    }
}
