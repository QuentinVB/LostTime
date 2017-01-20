using UnityEngine;
using Zenject;

interface IpositionEntity
{
    Vector3 getPosition();
}

public class PositionEntity : MonoBehaviour, IpositionEntity
{
    Vector3 position;
    string nameOfPosition;
    string name;
    //string nameOfEntityAtThisPosition;
    //bool isEmpty;

    PositionEntity(string name)
    { 
        position = new Vector3(10, 10, 10);
        nameOfPosition = "Park";
    }

     public Vector3 getPosition()
    {
        return position;
    }
}
