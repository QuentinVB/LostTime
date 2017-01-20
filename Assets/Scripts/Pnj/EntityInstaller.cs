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
           // foreach (UsefulEntityForCurrentQuest usefulEntity in toto.stamp)
                Container.Bind<UsefulEntityForCurrentQuest>().FromInstance(); // verifier difference entre assingle ,transcient, ascached
            Container.Bind<IpositionEntity>();
            Container.Bind<IinteractionWithUser>(); // done 
            Container.Bind<IbehaviourEntity>(); // done
                                                //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
            Container.Bind<Entity>();
        }
    }
}
