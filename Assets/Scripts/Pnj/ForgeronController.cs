using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForgeronController : MonoBehaviour {

    private Forgeron forgeron;
    public bool OntouchPlayer;
    public Collider collisionPlayer;
    public bool showPnjName;
    string StringForgeronTalk;




    public Canvas _canvas;
    void Start()
    {
        OntouchPlayer = false;
        forgeron = new Forgeron();
        showPnjName = false;
    }
    void OnGUI()
    {
        if (OntouchPlayer)
        {
            GUI.BeginGroup(new Rect(new Vector2(Screen.width / 2 - 150, Screen.height / 2 - 75), new Vector2(300, 150)));
            GUI.Label(new Rect(new Vector2(10, 50), new Vector2(280, 150)), "Forgeron : " + StringForgeronTalk);
            GUI.EndGroup();

          //  _canvas.GetComponent<RectTransform>().rect.width
        }

        else if (showPnjName)
        {
            GUI.Label(new Rect(new Vector2(10, 20), new Vector2(50, 20)), "Forgeron");
        }
    }

    private void OnMouseUp()
    {
        if (showPnjName == true )
        {
            OntouchPlayer = true;
            StringForgeronTalk = forgeron.callStateCurrent(collisionPlayer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            showPnjName = true;
            collisionPlayer = other;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        OntouchPlayer = false;
        collisionPlayer = null;
        showPnjName = false;
        StringForgeronTalk = "";
    }

    interface IControlerForgeron
    {
         string forgeronTalk(Forgeron context, Collider otherObject);
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


        public string callStateCurrent(Collider otherObject)
        {
           return currentStatesInstance.forgeronTalk(this, otherObject);
        }
    }


    class Neutral : IControlerForgeron
    {
        public string forgeronTalk(Forgeron context, Collider otherObject) {

            if (otherObject.gameObject.tag == "Player")
            {
                        PlayerQuest player  = otherObject.gameObject.GetComponent<PlayerQuest>();
                if (player.Quest)
                {
                    context.changeState(new Quest());
                    return "J'ai perdu mon marteau, peux tu aller me le chercher ?";
                }
                else
                    return "Attention !!! J'ai falli perdre mon marteau ! Jette un coup d'oeil sur le tableau des quêtes de la guilde ,tu traineras moins dans mes pattes.";
            }
            else
            {
                return "Attention !!! J'ai falli perdre mon marteau !";
            }
        }
    }

     class Quest : IControlerForgeron
    {

        public string forgeronTalk(Forgeron context, Collider otherObject)
        {
            PlayerQuest player = otherObject.gameObject.GetComponent<PlayerQuest>();
            if (player.inventory.Contains("Marteau"))
            {
                context.changeState(new ValidateQuest());
                return"Genial tu as retrouvé mon Marteau !!! Pour te recompenser je t'offre .... ce Marteau !";
            }
            else
                return "Alors tu as trouvé mon marteau ?";
        }
    }

    class ValidateQuest : IControlerForgeron
    {
        public string forgeronTalk(Forgeron context, Collider otherObject)
        {
            return"Encore merci pour ton service. Je n'oublirais jamais.";
        }
    }
}