using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeavePanelScript : MonoBehaviour, IPointerDownHandler
{

	public virtual void OnPointerDown(PointerEventData leave)
    {
        if(leave.position.x > 0 && leave.position.y > 0)
        {
            Destroy(this.gameObject);
        }
    }
	
}
