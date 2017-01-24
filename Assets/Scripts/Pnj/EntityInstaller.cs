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
        //Debug.Log(string.Format("questManager: {0}", questManager == null ? "is null" : "is not null"));
        //Debug.Log(string.Format("questManager.NPCList.Count: {0}", questManager.NPCList.Count));
        //LinkedActor temp = questManager.NPCList[0];
        //Debug.Log(temp.job);
        Container.Bind<ISculptor>().To<HumanSculptor>().AsTransient();
        Container.Bind<QuestManager>().AsSingle();
        Container.Bind<LinkedActor>().AsTransient();
        //Container.Bind<LinkedActor>().FromInstance(questManager.NPCList[questManager.count]); // verifier difference entre assingle ,transcient, ascached
        //if (questManager.NPCList[questManager.count] != null)
        //    
        //else
        //    Debug.Log("La puta madre\n");
        //questManager.count++;
        //Container.Bind<LinkedActor>().FromInstance(new LinkedActor { id = "id2", name = "tutu", job = "poubelier" });
        //if (questManager.NPCList[questManager.count].job != null)
        Container.Bind<IPosition>().To<PositionEntity>();
                                            //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
        Container.Bind<Entity>();
        Debug.Log("Bindings ended.");
    }
}
