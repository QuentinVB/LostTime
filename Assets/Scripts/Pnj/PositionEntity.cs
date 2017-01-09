using UnityEngine;
using Zenject;

interface IpositionEntity
{
    PositionEntity instantiateIPositionEntity(InjectContext context);
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

     public PositionEntity instantiateIPositionEntity(InjectContext context)
    {
        return this;
    }
}
