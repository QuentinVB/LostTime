using UnityEngine;
using System.Collections;

public class QuestTableScript : MonoBehaviour {

    private GameObject Marteau;
   // private Rigidbody QuestTableRigidbody;

	void Start () {
      //  QuestTableRigidbody = gameObject.AddComponent<Rigidbody>();
        Marteau = GameObject.Find("Marteau");
        Marteau.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerQuest player = collision.gameObject.GetComponent<PlayerQuest>();
            if (player.Quest == false)
                Marteau.SetActive(true);
            player.Quest = true;
        }
    }
}
