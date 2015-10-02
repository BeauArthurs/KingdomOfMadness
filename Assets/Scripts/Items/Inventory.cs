using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Boy Voesten

    // TODO:
    //  - A lot

public class Inventory : MonoBehaviour
{
    private GameObject _inventoryPanel;
    private GameObject _slotPanel;
    private ItemDB _itemDB;
    [SerializeField] private GameObject _UIManager;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private int _slotAmount = 21;

    void Start()
    {
        _itemDB = GetComponent<ItemDB>();

        // Instantiate all the slots in the inventory
        SpawnSlots(_slotAmount);
        
        // Add some items to the inventory test it
        AddItem(0);
        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(2);
        AddItem(3);

        // Hide UI after done doing all the loading
        _UIManager.GetComponent<Tools>().ToggleUIMode();
    }

    private void SpawnSlots(int amount)
    {
        _inventoryPanel = GameObject.Find("InventoryPanel");
        _slotPanel = _inventoryPanel.transform.FindChild("SlotPanel").gameObject;

        for (int i = 0; i < amount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(_slotPanel.transform, false);
        }
    }
    
    public void AddItem(int id)
    {
        Item itemToAdd = _itemDB.FetchItemByID(id);

        // Check if it's stackable and already exists
        if (itemToAdd.Stackable && IsInInventory(itemToAdd)) 
        {
            for (int i = 0; i < items.Count; i++) 
            {
                // Find the stack
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
                // Look for an empty slot
                if(items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
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
    bool IsInInventory(Item item) 
    {
        for (int i = 0; i < items.Count; i++) 
        {
            if (items[i].ID == item.ID)
                return true;
        }
        return false;
    }

}
