using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;







public class EntitysInstaller : MonoInstaller
{
    QuestManager questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
    public override void InstallBindings()
    {
        foreach (LinkedActor actor in questManager.QuestContainer.setUpActorList)
            EntityInstaller.Install(Container);
    }
}

public class EntityInstaller : Installer<EntityInstaller>
{
    QuestManager questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
    public void chooseMyPrefab()
    {

    }
    public override void InstallBindings()
    {
        Container.Bind<LinkedActor>().FromInstance(questManager.QuestContainer.setUpActorList[questManager.count]); // verifier difference entre assingle ,transcient, ascached
        Container.Bind<ISculptor>();
        Container.Bind<Iposition>();
        Container.Bind<IinteractionWithUser>(); // done 
        Container.Bind<IbehaviourEntity>(); // done
                                            //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
        Container.Bind<Entity>();
    }
}
