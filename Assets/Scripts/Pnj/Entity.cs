using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IpositionEntity
{

    Transform InitialPosition;

    IpositionEntity positionEntity;
    IbehaviourEntity behaviourEntity;
    IpathFindingEntity pathFindingEntity;
    IinteractionWithUser interactionWithUser;
    //ISculptor sculptor;

    // Entity se qui peut ce deplacer + interagir + comportement
    Entity(IpositionEntity _positionEntity, IbehaviourEntity _behaviourEntity,
        IpathFindingEntity _pathFindingEntity, IinteractionWithUser _interactionWithUser)
    {
        positionEntity = _positionEntity;
        behaviourEntity = _behaviourEntity;
        pathFindingEntity = _pathFindingEntity;
        interactionWithUser = _interactionWithUser;

        InitialPosition.position = positionEntity.getPosition();
        this.transform.position = positionEntity.getPosition();

    }
    public Vector3 getPosition()
    {
        return positionEntity.getPosition(); ; ;
    }
    //Entity se qui peut ce deplacer + comportement
}
