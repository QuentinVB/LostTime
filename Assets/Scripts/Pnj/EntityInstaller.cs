using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

interface IpathFindingEntity
{
    // par vivan
}

public class EntitysInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        EntityInstaller.Install(Container);
        EntityInstaller.Install(Container);
        EntityInstaller.Install(Container);
        EntityInstaller.Install(Container);
        EntityInstaller.Install(Container);

    }

}


public class EntityInstaller : Installer<EntityInstaller>
{

    public struct Who
    {
        public string name;
        public Who(string name){
            this.name = name;
        }
    }




    public override void InstallBindings()
    {


        Container.Bind<Who>();
        Container.Bind<IpositionEntity>();
        Container.Bind<IinteractionWithUser>(); // done 
        Container.Bind<IbehaviourEntity>(); // done
        //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
        Container.Bind<Entity>();
    }
}


public class Entity : MonoBehaviour
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

        this.transform.position = positionEntity.getPosition();

    }
    //Entity se qui peut ce deplacer + comportement
    Entity(IpositionEntity _positionEntity,
        IpathFindingEntity _pathFindingEntity)
    {
        positionEntity = _positionEntity;
        behaviourEntity = null;
        pathFindingEntity = _pathFindingEntity;
        interactionWithUser = null;

        this.transform.position = positionEntity.getPosition();
    }

    Entity(IpositionEntity _positionEntity, IbehaviourEntity _behaviourEntity,
        IinteractionWithUser _interactionWithUser)
    {
        positionEntity = _positionEntity;
        behaviourEntity = _behaviourEntity;
        pathFindingEntity = null;
        interactionWithUser = _interactionWithUser;

        this.transform.position = positionEntity.getPosition();
    }

    Entity(IpositionEntity _positionEntity)
    {
        positionEntity = _positionEntity;
        behaviourEntity = null;
        pathFindingEntity = null;
        interactionWithUser = null;

        this.transform.position = positionEntity.getPosition();
    }
}
