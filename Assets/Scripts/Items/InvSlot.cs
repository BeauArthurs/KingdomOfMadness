using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

// Boy Voesten

// TODO:
//  Improve the way I switch items from slots

public class InvSlot : MonoBehaviour, IDropHandler
{
    public int id;
    private Inventory _inv;

    void Start()
    {
        _inv = GameObject.FindGameObjectWithTag(TagList.Inventory).GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (_inv.items[id].ID == -1)
        {
            // Clear out the old slot first
            _inv.items[droppedItem.slotID] = new Item();
            _inv.items[id] = droppedItem.item;
            // Set the id to the new one
            droppedItem.slotID = id;
        }
        else
        {
            // Switch slots of items
            Transform currentItem = transform.GetChild(0);

            currentItem.GetComponent<ItemData>().slotID = droppedItem.slotID;
            currentItem.transform.SetParent(_inv.slots[droppedItem.slotID].transform);
            currentItem.transform.position = _inv.slots[droppedItem.slotID].transform.position;

            droppedItem.slotID = id;
            droppedItem.transform.SetParent(transform);
            droppedItem.transform.position = transform.position;

            _inv.items[droppedItem.slotID] = currentItem.GetComponent<ItemData>().item;
            _inv.items[id] = droppedItem.item;
        }
    }
}
