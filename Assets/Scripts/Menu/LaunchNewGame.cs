using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchNewGame : MonoBehaviour {

    private bool _saveStateUsed;
	void Start () {
		if(_saveStateUsed == false)
        {
            Debug.Log("We will save your progress here");
            SceneManager.LoadScene("LostTimeGearDistrict");
        }
        else
        {
            Debug.Log("This state is already used. Do you want to save on this state");
            // créer 2 buttons yes / no qui valide la choix. Récupérez le choix ici. Et agir en conséquences.
            // oui : lancez le jeu.
            // Non : Revenir au menu. 
        }
	}
}
