using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForgeronController : MonoBehaviour {

    private Forgeron forgeron;
    public bool OnCollisionWithPlayer;
    public bool IstriggerPlayer;
    public Collider collisionPlayer;
    public bool showGui;

    void Start()
    {
        OnCollisionWithPlayer = false;
        IstriggerPlayer = false;
        forgeron = new Forgeron();
        showGui = false;
    }
    void OnGUI()
    {
        if (showGui)
        {
            GUI.BeginGroup(new Rect(new Vector2(Screen.width / 2 - 150 , Screen.height / 2 - 75) , new Vector2(300, 150)));
            GUI.Label(new Rect(new Vector2(10, 20),new Vector2( 280, 150)), "Forgeron");
            GUI.EndGroup();
        }
    }

    private void OnMouseUp()
    {
        if (OnCollisionWithPlayer == true )
        {
            showGui = true;
            OnGUI();
            forgeron.callStateCurrent(collisionPlayer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //OnGUI();
            OnCollisionWithPlayer = true;
            collisionPlayer = other;
           

        }
    }


    private void OnTriggerExit(Collider other)
    {
        OnCollisionWithPlayer = false;
        collisionPlayer = null;
        IstriggerPlayer = false;
        showGui = false;
    }

    interface IControlerForgeron
    {
         void forgeronTalk(Forgeron context, Collider otherObject);
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


        public void callStateCurrent(Collider otherObject)
        {
            currentStatesInstance.forgeronTalk(this, otherObject);
        }
    }


    class Neutral : IControlerForgeron
    {
        public void forgeronTalk(Forgeron context, Collider otherObject) {

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

        public void forgeronTalk(Forgeron context, Collider otherObject)
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
        public void forgeronTalk(Forgeron context, Collider otherObject)
        {
            Debug.Log("Encore merci pour ton service. Je n'oublirais jamais.");
        }
    }
}