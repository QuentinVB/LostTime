using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

interface IpathFindingEntity
{
    // par vivan
}



public class EntityInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IpositionEntity>().FromInstance(new PositionEntity());
        Container.Bind<IinteractionWithUser>().FromInstance(new interactionWithUser());
        Container.Bind<IbehaviourEntity>().FromInstance(new ForgeronController());
        //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
        Container.Bind<Entity>().FromNew();
    }
}

public class Entity
{
    IpositionEntity positionEntity;
    IbehaviourEntity behaviourEntity;
    IpathFindingEntity pathFindingEntity;
    IinteractionWithUser interactionWithUser;

    // Entity se qui peut ce deplacer + interagir + comportement
    Entity(IpositionEntity _positionEntity, IbehaviourEntity _behaviourEntity,
        IpathFindingEntity _pathFindingEntity, IinteractionWithUser _interactionWithUser)
    {
        positionEntity = _positionEntity;
        behaviourEntity = _behaviourEntity;
        pathFindingEntity = _pathFindingEntity;
        interactionWithUser = _interactionWithUser;

    }
    //Entity se qui peut ce deplacer + comportement
    Entity(IpositionEntity _positionEntity,
        IpathFindingEntity _pathFindingEntity)
    {
        positionEntity = _positionEntity;
        behaviourEntity = null;
        pathFindingEntity = _pathFindingEntity;
        interactionWithUser = null;
    }

    Entity(IpositionEntity _positionEntity, IbehaviourEntity _behaviourEntity,
        IinteractionWithUser _interactionWithUser)
    {
        positionEntity = _positionEntity;
        behaviourEntity = _behaviourEntity;
        pathFindingEntity = null;
        interactionWithUser = _interactionWithUser;
    }

    Entity(IpositionEntity _positionEntity)
    {
        positionEntity = _positionEntity;
        behaviourEntity = null;
        pathFindingEntity = null;
        interactionWithUser = null;
    }
}
