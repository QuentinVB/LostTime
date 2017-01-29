using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaireScript : MonoBehaviour {

    List<InventaireScript> _playerInventory;

    private string _itemName;
    private string _itemDescription;
    private bool _usefulItem;
    private bool _rareItem;
    private bool _questItem;

    private void Start()
    {
        _playerInventory = new List<InventaireScript>();
        AddTestObejctInList();
    }

    public InventaireScript(string ItemName, string ItemDescription, bool UsefulItem, bool Rareitem, bool QuestItem)
    {
        
        _itemName = ItemName;
        _itemDescription = ItemDescription;
        _usefulItem = UsefulItem;
        _rareItem = Rareitem;
        _questItem = QuestItem;
    }

    public void AddTestObejctInList()
    {
        _playerInventory.Add(new InventaireScript("Marteau", "Objet commun de travail", true, false, false));
        _playerInventory.Add(new InventaireScript("Livre", "Objet commun pour se cultiver ou trouver de l'aide", true, false, false));
        _playerInventory.Add(new InventaireScript("Morceau n°1 de l'horloge", "Objet de quête principale", false, true, true));
        _playerInventory.Add(new InventaireScript("Montre de la famille", "Object de famille venant de votre grand-mère", false, true, false));
    }

    public List<InventaireScript> GetInventoryItem
    {
        get { return _playerInventory; }
    }

    public string GetItemName
    {
        get { return _itemName; }
    }

    public string GetItemDescription
    {
        get { return _itemDescription; }
    }

    public bool GetUsefulItem
    {
        get { return _usefulItem; }
    }

    public bool GetRareItem
    {
        get { return _rareItem; }
    }

    public bool GetQuestItem
    {
        get { return _questItem; }
    }
}
