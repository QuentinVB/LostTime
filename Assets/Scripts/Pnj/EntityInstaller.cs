using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


//public class EntitysInstaller : MonoInstaller, IDisposable
//{
//    QuestManager questManager = GameObject.Find("QuestTable").GetComponent<QuestManager>();
//    public override void InstallBindings()
//    {
//        Debug.Log("EntitysInstaller");
//        foreach (LinkedActor actor in questManager.NPCList)
//            EntityInstaller.Install(Container);
//    }

//    public void Dispose()
//    {
//        //
//    }
//}

public class EntityInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<QuestManager>().AsSingle().NonLazy();      
            Container.Bind<IPosition>().To<PositionEntity>().NonLazy();
            
            Container.Bind<ISculptor>().To<HumanSculptor>().AsCached().NonLazy();
            Container.Bind<LinkedActor>().NonLazy();
            Container.Bind<IpathFinding>().To<Pathfinding>().NonLazy();
            Container.Bind<Entity>().To<Entity>().NonLazy();
        //Debug.Log(string.Format("questManager: {0}", questManager == null ? "is null" : "is not null"));
        //Debug.Log(string.Format("questManager.NPCList.Count: {0}", questManager.NPCList.Count));
        Debug.Log("Bindings ended.");
    }
}
