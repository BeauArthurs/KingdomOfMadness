using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private GameObject _inventoryPanel;
    private GameObject _slotPanel;
    private ItemDB _itemDB;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    private int _slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        _itemDB = GetComponent<ItemDB>();

        _slotAmount = 21;
        _inventoryPanel = GameObject.Find("InventoryPanel");
        _slotPanel = _inventoryPanel.transform.FindChild("SlotPanel").gameObject;
        for(int i = 0; i < _slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(_slotPanel.transform, false);
        }


        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
    }
    
    public void AddItem(int id)
    {
        Item itemToAdd = _itemDB.FetchItemByID(id);

        // Check if it's stackable
        if (itemToAdd.Stackable && IsInInventory(itemToAdd)) 
        {
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i].ID == id) 
                {
                    // Increase stack amount by 1
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        } 
        else 
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.transform.SetParent(slots[i].transform, false);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = items[i].Title;
                    slots[i].name = "Holding: " + itemObj.name;
                    break;
                }
            }
        }

        
    }

    // Check if item already exists in inventory
    bool IsInInventory(Item item) {
        for (int i = 0; i < items.Count; i++) 
        {
            if (items[i].ID == item.ID)
                return true;
        }
        return false;
    }

}
