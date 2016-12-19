using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvent : MonoBehaviour {

    public void LaunchGame()
    {
        SceneManager.LoadScene("LostTimeEnvironement3D");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
