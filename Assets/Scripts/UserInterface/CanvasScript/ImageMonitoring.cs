using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMonitoring : MonoBehaviour {


    public Sprite _MapPanel;
    public Sprite _DownArrow;
    public Sprite _knob;
    public Sprite _mapButton;
    public Sprite _ConfigButton;
    public Sprite _QuestButton;
    public Sprite _LeaveButton;
    public Sprite _BagButton;
    public Sprite _WoodBackGround;
    public Sprite _MetalCircle;
    public Sprite _yellowGear;

    public Sprite _backGround1;
    public Sprite _backGround2;
    public Sprite _backGround3;
    public Sprite _backGround4;
    public Sprite _backGround5;
    public Sprite _inventoryBackGround;

    public Sprite _pub01;
    public Sprite _pub02;
    public Sprite _pub03;



    public void PutBackGroundImageOnGameObject(string GameObjectName, string GameObjectParentName, Sprite BackGround, 
        bool LeftLimitSprite, Sprite BackGroundLimitLeft,
        bool RightLimitSprite, Sprite BackGroundLimitRight,
        bool UpLimitSprite, Sprite BackGroundLimitUp,
        bool DownLimitSprite, Sprite BackGroundLimitDown, 
        float LimitSizeX, float LimitSizeY)
    {
        this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName, GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height,
                    0, 0, BackGround);

        if(LeftLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "LeftLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    -(GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2) 
                    + (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2) / LimitSizeX,
                    0, BackGroundLimitLeft);
        }

        if(RightLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "RightLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2
                    - (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / 2) / LimitSizeX),
                    0, BackGroundLimitRight);
        }

        if(UpLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "UpLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    0, (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2
                    - (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2) / LimitSizeY),
                    BackGroundLimitUp);
        }

        if(DownLimitSprite == true)
        {
            this.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "DownLimit", GameObject.Find(GameObjectParentName), true,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.width / LimitSizeX,
                    GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / LimitSizeY,
                    0, -(GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2)
                    + (GameObject.Find(GameObjectParentName).GetComponent<RectTransform>().rect.height / 2) / LimitSizeY,
                    BackGroundLimitDown);
        }
    }
    


    public Sprite GetInventoryBagBackGround
    {
        get { return _inventoryBackGround; }
    }

    public Sprite GetBackGround1
    {
        get { return _backGround1; }
    }

    public Sprite GetBackGround2
    {
        get { return _backGround2; }
    }

    public Sprite GetBackGround3
    {
        get { return _backGround3; }
    }

    public Sprite GetBackGround4
    {
        get { return _backGround4; }
    }

    public Sprite GetBackGround5
    {
        get { return _backGround5; }
    }

    public Sprite GetPub1
    {
        get { return _pub01; }
    }

    public Sprite GetPub2
    {
        get { return _pub02; }
    }

    public Sprite GetPub3
    {
        get { return _pub03; }
    }

    public Sprite GetWoodBackGround
    {
        get { return _WoodBackGround; }
    }

    public Sprite GetMetalCircle
    {
        get { return _MetalCircle; }
    }

    public Sprite GetMapPanel
    {
        get { return _MapPanel; }
    }

    public Sprite GetDownArrow
    {
        get { return _DownArrow; }
    }

    public Sprite GetKnob
    {
        get { return _knob; }
    }

    public Sprite GetMapButton
    {
        get { return _mapButton; }
    }

    public Sprite GetConfigButton
    {
        get { return _ConfigButton; }
    }

    public Sprite GetQuestButton
    {
        get { return _QuestButton; }
    }

    public Sprite GetLeaveButton
    {
        get { return _LeaveButton; }
    }

    public Sprite GetBagButton
    {
        get { return _BagButton; }
    }

    public Sprite GetYellowGear
    {
        get { return _yellowGear; }
    }
}
