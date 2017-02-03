using UnityEngine;
using System.Collections;
using System.Collections.Generic;


class PlayerQuest : MonoBehaviour
{
    public List<string> inventory;
    public bool Quest;

    void Start()
    {

        Quest = false;
        inventory = new List<string>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Marteau")
        {
            inventory.Add("Marteau");
            collision.gameObject.SetActive(false);
        }
    }
}