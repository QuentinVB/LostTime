using UnityEngine;
using Zenject;
using System.Xml.Serialization;
using System.Collections.Generic;

interface Iposition
{
    Vector3 getPosition();
}

public class PositionEntity : MonoBehaviour, Iposition
{
    Vector3 position;
    string nameOfPosition;
    List<Position> positionList = new List<Position>();

    public class Position
    {
       // string NPCIWant;
       // string name;
        public bool isSetUp;
        public Vector3 position;

        public Vector3 getPosition()
        {
            return this.position;
        }
    }


    void Start()
    {
        positionList.Add(new Position { isSetUp = false, position =  new Vector3(17.6f, -0.04f, -21.3f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(17.6f, -0.04f, -21.3f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(16.48f, 0.87f, 55.57f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(-22.5f, 1.915f, 23.9f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(-19.1f, 1.915f, 35.3f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(-19.1f, 1.88f, -26.5f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(14.2f, 1.959f, -49.6f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(29.1f, -0.044f, 32.1f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(-12.52f, 0.98f, 7.67f) });
        positionList.Add(new Position { isSetUp = false, position = new Vector3(-23.86f, 1.91f, -13.1f) });
    }

    public Vector3 getPosition()
    {
        return positionList[0].getPosition();
    }
}
