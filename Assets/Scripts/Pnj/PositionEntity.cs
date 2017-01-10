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
    //string nameOfEntityAtThisPosition;
    //bool isEmpty;

    void Start()
    {
        position = new Vector3(10, 10, 10);
        nameOfPosition = "Park";
    }

     public Vector3 getPosition()
    {
        return position;
    }
}
