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
        Container.Bind<QuestManager>().AsSingle();

        for (int index = 0; index <= 10; index++)
        {
            Container.Bind<int>().FromInstance(index);
            Container.Bind<ISculptor>().To<HumanSculptor>().AsCached();
            Container.Bind<LinkedActor>().AsTransient();
            Container.Bind<IPosition>().To<PositionEntity>();
            Container.Bind<Entity>();
        }
        //Debug.Log(string.Format("questManager: {0}", questManager == null ? "is null" : "is not null"));
        //Debug.Log(string.Format("questManager.NPCList.Count: {0}", questManager.NPCList.Count));
        //LinkedActor temp = questManager.NPCList[0];
        //Debug.Log(temp.job);
        //Container.Bind<LinkedActor>().AsTransient();
        //if (questManager.NPCList[questManager.count] != null)
        //    
        //else
        //    Debug.Log("La puta madre\n");
        //questManager.count++;
        //Container.Bind<LinkedActor>().FromInstance(new LinkedActor { id = "id2", name = "tutu", job = "poubelier" });
        //if (questManager.NPCList[questManager.count].job != null)

        //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());

        //Debug.Log("Bindings ended.");
    }
}
