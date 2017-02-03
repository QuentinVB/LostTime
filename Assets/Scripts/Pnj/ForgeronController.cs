using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ForgeronController : MonoBehaviour
{
    private Forgeron forgeron;
    public bool OntouchPlayer;
    public Collider collisionPlayer;
    public bool onTrigger;
    string StringForgeronTalk;
    public Text _displayDialogue;
    public GameObject Marteau;


    void Start()
    {

        _displayDialogue = GameObject.Find("DisplayDialogue").GetComponent<Text>();
        collisionPlayer = GameObject.Find("AstridPlayer").GetComponent<Collider>();
        OntouchPlayer = false;
        forgeron = new Forgeron();
        onTrigger = false;
        Debug.Log(string.Format("le tag d'astrid est : {0}", collisionPlayer.tag));
        Marteau = GameObject.Find("MarteauPa");
        Debug.Log(Marteau);
        Marteau.SetActive(false);
        ////////////////////////////////////AstrifPlayer////
        _displayDialogue.verticalOverflow = VerticalWrapMode.Overflow;               ////////////////////////////////////////
        _displayDialogue.text = "";                ////////////////////////////////////////
    }


    void OnGUI()
    {
        if (OntouchPlayer == true)
        {
            _displayDialogue.text = "Forgeron : " + StringForgeronTalk;
        }
    }

    private void OnMouseUp()
    {
        if (onTrigger)
        OntouchPlayer = true;
        StringForgeronTalk = forgeron.callStateCurrent(collisionPlayer);
    }
    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        OntouchPlayer = false;
        _displayDialogue.text = "";
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
        public GameObject Marteau;

        public Neutral()
        {
            Marteau = GameObject.Find("MarteauPa");

        }
        public string forgeronTalk(Forgeron context, Collider otherObject)
        {
            if (otherObject.tag == "Player")
            {
                PlayerQuest player = otherObject.GetComponent<PlayerQuest>();
                context.changeState(new QuestF());
                Marteau.SetActive(true);
                return "J'ai perdu mon marteau, peux tu aller me le chercher ?";
            }
            else
            {
                return "";
            }
        }
    }

    class QuestF : IControlerForgeron
    {

        public string forgeronTalk(Forgeron context, Collider otherObject)
        {
            PlayerQuest player = otherObject.gameObject.GetComponent<PlayerQuest>();
            if (player.inventory.Contains("Marteau"))
            {
                context.changeState(new ValidateQuest());
                return "Genial tu as retrouvé mon Marteau !!! Pour te recompenser je t'offre .... ce Marteau !";
            }
            else
                return "Alors tu as trouvé mon marteau ?";
        }
    }

    class ValidateQuest : IControlerForgeron
    {
        public string forgeronTalk(Forgeron context, Collider otherObject)
        {
            return "Encore merci pour ton service. Je n'oublirais jamais.";
        }
    }
}