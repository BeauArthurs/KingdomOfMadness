using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Boy Voesten

// TODO:
//  Make the items equipable
//  Add some kind of currency
//  Don't allow the player to buy if inventory is full

public class Inventory : MonoBehaviour
{

    private const string INV_PANEL = "InventoryPanel";
    private const string SLOT_PANEL = "SlotPanel";

    private GameObject _inventoryPanel;
    private GameObject _slotPanel;
    private ItemDB _itemDB;
    [SerializeField]
    private GameObject _UIManager;
    public GameObject emptyInvSlot;
    public GameObject emptyInvItem;
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
        AddItem(2);
        AddItem(1);
        AddItem(3);
        AddItem(2);
        AddItem(0);
        AddItem(3);
        AddItem(1);

        // Hide UI after done doing all the loading
        _UIManager.GetComponent<Tools>().ToggleUIMode();
    }

    private void SpawnSlots(int amount)
    {
        _inventoryPanel = GameObject.Find(INV_PANEL);
        _slotPanel = _inventoryPanel.transform.FindChild(SLOT_PANEL).gameObject;

        for (int i = 0; i < amount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(emptyInvSlot));
            slots[i].GetComponent<InvSlot>().id = i;
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
        else if (SpaceInInventory())
        {
            for (int i = 0; i < items.Count; i++)
            {
                // Get the first empty item in the list
                if (items[i].ID == -1)
                {
                    GameObject itemObj = Instantiate(emptyInvItem);
                    ItemData itemObjData = itemObj.GetComponent<ItemData>();

                    items[i] = itemToAdd;
                    itemObjData.item = itemToAdd;
                    itemObjData.slotID = i;
                    itemObj.transform.SetParent(slots[i].transform, false);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = items[i].Title;
                    slots[i].name = "Holding: " + itemObj.name;
                    break;
                }
            }
        }
        else
        {
            Debug.Log("- Inventory full -");
            // It should return something
        }
    }

    bool SpaceInInventory()
    {
        int amount = 0;
        foreach (Item item in items)
        {
            if (item.ID != -1)
            {
                amount++;
            }
        }
        Debug.Log(amount);
        return (amount < _slotAmount);
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
