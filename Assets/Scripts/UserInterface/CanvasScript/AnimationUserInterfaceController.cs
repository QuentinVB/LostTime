using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUserInterfaceController : MonoBehaviour {

    private float _AnimationSpeed = 20f;

    public float GetAnimationSpeed
    {
        get { return _AnimationSpeed; }
    }


    public bool VrtAnimToUserInterface(string GameObjectName, float finalePositionX, float finalePositionY, int direction)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(0, _AnimationSpeed * direction);

        if (GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.y <= finalePositionY)
        {
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition
                = new Vector2(finalePositionX, finalePositionY);
            return false;
        }
        return true;
    }

    public bool VrtAnimToDestroy(string GameObjectName, float finalePositionY, int direction)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(0, _AnimationSpeed * direction);

        if (finalePositionY <= GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.y)
        {
            Destroy(GameObject.Find(GameObjectName));
            return false;
        }
        return true;
    }

    //public bool HztAnimToUserInterfaceRightToLeft(string GameObjectName, float finalePositionX, float finalePositionY, int direction)
    //{
    //    GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
    //        new Vector2(_AnimationSpeed * direction, 0);

    //    if (GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x <= finalePositionX)
    //    {
    //        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition
    //            = new Vector2(finalePositionX, finalePositionY);
    //        return false;
    //    }
    //    return true;
    //}

    //public bool HztAnimToDestroyLeftToRight(string GameObjectName, float finalePositionX, int direction)
    //{
    //    GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
    //        new Vector2(_AnimationSpeed * direction, 0);

    //    if(finalePositionX <= GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x)
    //    {
    //        Destroy(GameObject.Find(GameObjectName));
    //        return false;
    //    }
    //    return true;
    //}

    public bool HztAnimToUserInterfaceLeftToRight(string GameObjectName, float finalePositionX, float finalePositionY, int direction)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(_AnimationSpeed * direction, 0);

        if (finalePositionX <= GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x)
        {
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition
                = new Vector2(finalePositionX, finalePositionY);
            return false;
        }
        return true;
    }

    public bool HztAnimToDestroyRightToLeft(string GameObjectName, float finalePositionX, int direction)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition +=
            new Vector2(_AnimationSpeed * direction, 0);

        if (GameObject.Find(GameObjectName).GetComponent<RectTransform>().anchoredPosition.x <= finalePositionX)
        {
            Destroy(GameObject.Find(GameObjectName));
            return false;
        }
        return true;
    }

    public void RotationObjectOnAxe(string GameObjectName, float x, float y , float z)
    {
        GameObject.Find(GameObjectName).GetComponent<RectTransform>().transform.Rotate(x * _AnimationSpeed, y * _AnimationSpeed, z * _AnimationSpeed); 
    }
}
