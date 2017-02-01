using System;
using UnityEngine;
using Zenject;
/// <summary>
/// UNUSED
/// </summary>
public class CrossDependecyResolver
{
    NPCSpawner npcSpawner;
    QuestManager questManager;
    [Inject]
    public CrossDependecyResolver(NPCSpawner npcSpawner, QuestManager questManager)
    {
        this.questManager = questManager;
        this.npcSpawner = npcSpawner;
        Debug.Log("CrossDependencyLoaded");
        npcSpawner.QuestManagerInjector = questManager;
        questManager.NPCSpawnerInjector = npcSpawner;
        Debug.Log("CrossDependencyResolved");

    }

}