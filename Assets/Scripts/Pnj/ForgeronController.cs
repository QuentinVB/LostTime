using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForgeronController : MonoBehaviour {

    private Forgeron forgeron;

    void Start()
    {
        forgeron = new Forgeron();
    }

    private void OnCollisionEnter(Collision collision)
    {
        forgeron.callStateCurrent(collision);
    }

    interface IControlerForgeron
    {
         void forgeronTalk(Forgeron context,  Collision otherObject);
    }

    class Forgeron
    {
        private IControlerForgeron currentStatesInstance;


        public Forgeron()
        {
            currentStatesInstance = new Neutral();
        }

        
        public void changeState(IControlerForgeron StatesInstance)
        {
            currentStatesInstance = StatesInstance;
        }


        public void callStateCurrent(Collision otherObject)
        {
            currentStatesInstance.forgeronTalk(this, otherObject);
        }
    }


    class Neutral : IControlerForgeron
    {
        public void forgeronTalk(Forgeron context, Collision otherObject) {

            if (otherObject.gameObject.tag == "Player")
            {
                PlayerQuest player  = otherObject.gameObject.GetComponent<PlayerQuest>();
                if (player.Quest)
                {
                    Debug.Log("J'ai perdu mon marteau, peux tu aller me le chercher ?");
                    context.changeState(new Quest());
                }
                else
                    Debug.Log("Attention !!! J'ai falli perdre mon marteau ! Jette un coup d'oeil sur le tableau des quêtes de la guilde ,tu traineras moins dans mes pattes.");
            }
            else if (otherObject.gameObject.tag == "Entity" )
            {
                Debug.Log("Attention !!! J'ai falli perdre mon marteau !");
            }
        }
    }

     class Quest : IControlerForgeron
    {

        public void forgeronTalk(Forgeron context, Collision otherObject)
        {
            PlayerQuest player = otherObject.gameObject.GetComponent<PlayerQuest>();
            if (player.inventory.Contains("Marteau"))
            {
                Debug.Log("Genial tu as retrouvé mon Marteau !!! Pour te recompenser je t'offre .... ce Marteau !");
                context.changeState(new ValidateQuest());
            }
            else
                Debug.Log("Alors tu as trouvé mon marteau ?");
        }
    }

    class ValidateQuest : IControlerForgeron
    {
        public void forgeronTalk(Forgeron context, Collision otherObject)
        {
            Debug.Log("Encore merci pour ton service. Je n'oublirais jamais.");
        }
    }
}