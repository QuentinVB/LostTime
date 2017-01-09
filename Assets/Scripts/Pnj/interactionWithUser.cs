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
    public Text textFieldTest;
    void Start()
    { 
        textFieldTest = textFieldTest = GameObject.Find("TextFieldTest").GetComponent<Text>();
        textFieldTest.text = "test test";
    }

}
