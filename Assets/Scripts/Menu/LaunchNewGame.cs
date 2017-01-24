using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LaunchNewGame : MonoBehaviour, IPointerDownHandler
{

    public virtual void OnPointerDown(PointerEventData NewGame)
    {
        //Vérifiez que la current SaveState est vide
        // => Si oui, 
                // set currentSaveState à SaveState01
                // Charger CurrentPosition 'Astrid 
        // => Si non,
                // Demandez au joueurs si on écrase les données sur la save
                // Si oui
                // set currentsave = saveState 01
                // charger currentsPosition Astrid
    }
}
