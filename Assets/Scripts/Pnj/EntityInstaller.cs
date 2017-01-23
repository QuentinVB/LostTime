using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class EntitysInstaller : MonoInstaller, IDisposable
{
    QuestManager questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
    public override void InstallBindings()
    {
        foreach (LinkedActor actor in questManager.NPCList)
            EntityInstaller.Install(Container);
    }

    public void Dispose()
    {
        //
    }
}

public class EntityInstaller : Installer<EntityInstaller>
{
    QuestManager questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();

    public override void InstallBindings()
    {
        Container.Bind<LinkedActor>().FromInstance(questManager.NPCList[questManager.count]); // verifier difference entre assingle ,transcient, ascached
        questManager.count++;
        if (questManager.NPCList[questManager.count].job != null)
            Container.Bind<ISculptor>().FromInstance(new HumanSculptor());
        Container.Bind<Iposition>();
        Container.Bind<IinteractionWithUser>(); // done 
        Container.Bind<IbehaviourEntity>(); // done
                                            //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
        Container.Bind<Entity>();
    }
}
