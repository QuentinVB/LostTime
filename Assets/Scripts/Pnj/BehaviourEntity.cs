using System.Collections.Generic;
using UnityEngine;


interface IbehaviourEntity
{

}

public class BehaviourEntity : MonoBehaviour, IbehaviourEntity
{
    QuestManager questManager = null;
    string currentQuest = null;
    string currentAction = null;
    List<Quest> questList = null;

    // Use this for initialization
    private void OnMouseUp()
    {
        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
        currentQuest = questManager.questContainer.nameOfcurrentQuest;
        questList = questManager.questContainer.questCollection;
        
        }
        // checker s'il y a eu une mise a jour dans le fichier xml
        // checker si la quete en cours concerne le pnj courant
        // checker si linstruction en cours nous concerne 
        // executer l'instruction
    }



}
