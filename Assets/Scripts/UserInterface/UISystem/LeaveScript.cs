using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; 

public class LeaveScript : MonoBehaviour, IPointerDownHandler
{


    public virtual void OnPointerDown(PointerEventData Leave)
    {
        SceneManager.LoadScene("LostTimeMenuGame");
    }
}
