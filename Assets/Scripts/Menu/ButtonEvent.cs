using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvent : MonoBehaviour {

    public void LaunchGame()
    {
        SceneManager.LoadScene("LostTimeGearDistrict");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
