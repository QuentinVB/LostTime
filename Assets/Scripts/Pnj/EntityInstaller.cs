using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

interface IpathFindingEntity
{
    // par vivan
}

class Pnjs : MonoBehaviour
{
    List<UsefulEntityForCurrentQuest> stamp;
    List<UsefulEntityForCurrentQuest> usefulEntity;
    QuestManager questManager;
    string currentQuest = null;
    EntitysInstaller entitysInstaller;

    Pnjs()
    {
        entitysInstaller = new EntitysInstaller();
        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
    }
    private void Update()
    {
        if (currentQuest != questManager.currentQuest)
        {
            stamp = questManager.getCurrentEntityList();// a terminer insert nouveau entity dans la list
            putOnEntitysOnListOnlyIfDoesntExist();
            entitysInstaller.InstallBindings();
            usefulEntity = stamp;
            currentQuest = questManager.currentQuest;
        }
    }

    public void putOnEntitysOnListOnlyIfDoesntExist()
    {
        foreach(UsefulEntityForCurrentQuest stampElement in stamp)
        {
             foreach(UsefulEntityForCurrentQuest usefulEntityElement in usefulEntity)
            {
                if (usefulEntityElement.name.Equals(stampElement))
                {
                    stamp.Remove(stampElement);
                }
            }
        }
    }

    public class EntitysInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Pnjs toto = new Pnjs();
            foreach (UsefulEntityForCurrentQuest usefulEntity in toto.stamp)
                EntityInstaller.Install(Container);
        }
    }

    public class EntityInstaller : Installer<EntityInstaller>
    {
        public override void InstallBindings()
        {
            Pnjs toto = new Pnjs();
            foreach (UsefulEntityForCurrentQuest usefulEntity in toto.stamp)
                Container.Bind<UsefulEntityForCurrentQuest>().FromInstance(usefulEntity); // verifier difference entre assingle ,transcient, ascached
            Container.Bind<IpositionEntity>();
            Container.Bind<IinteractionWithUser>(); // done 
            Container.Bind<IbehaviourEntity>(); // done
                                                //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
            Container.Bind<Entity>();
        }
    }
}



public class Entity : MonoBehaviour
{
    Transform InitialPosition;

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

        InitialPosition.position = positionEntity.getPosition();
        this.transform.position = positionEntity.getPosition();

    }
    //Entity se qui peut ce deplacer + comportement
}
