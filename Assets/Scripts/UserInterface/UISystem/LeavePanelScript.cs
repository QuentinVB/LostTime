using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeavePanelScript : MonoBehaviour, IPointerDownHandler
{

	public virtual void OnPointerDown(PointerEventData leave)
    {
        Destroy(this.transform.parent.gameObject);
    }
}
