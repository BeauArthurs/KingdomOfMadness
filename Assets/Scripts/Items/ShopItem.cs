using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

// Boy Voesten

// TODO:
//  Find a way to do this without needing the info of the item and npc

public class ShopItem : MonoBehaviour, IPointerClickHandler
{

    public Item item;
    public NPC_Inventory npc;

    // When the player clicks on the item he wants to buy
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        npc.BuyItem(item.ID);
    }
}
