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

    private Sprite _itemSprite;

    private void Start()
    {
        _playerInventory = new List<InventaireScript>();
    }

    public InventaireScript(string ItemName, string ItemDescription, bool UsefulItem, bool Rareitem, bool QuestItem, Sprite ItemSprite)
    {
        
        _itemName = ItemName;
        _itemDescription = ItemDescription;
        _usefulItem = UsefulItem;
        _rareItem = Rareitem;
        _questItem = QuestItem;
        _itemSprite = ItemSprite;
    }

    public void AddTestObejctInList(string ItemName, string ItemDescription, bool UseFulItem, bool RareItem, bool QuestItem, Sprite ItemSprite)
    {
        _playerInventory.Add(new InventaireScript(ItemName, ItemDescription, UseFulItem, RareItem, QuestItem, ItemSprite));
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
