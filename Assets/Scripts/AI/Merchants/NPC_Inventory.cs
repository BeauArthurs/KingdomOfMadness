using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Boy Voesten

    // TODO:
    //  Improve the way I add items into the inventory

public class NPC_Inventory : MonoBehaviour {

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int[] _shopInventory;
    [SerializeField] private Transform itemPanel;
    [SerializeField] private float priceScale = 1f;

    private ItemDB _itemDB;
    private Inventory _inventory;

    // On interaction (Start for now), load all items into the itemPrefabs.

    void Start()
    {
        _itemDB = GameObject.FindGameObjectWithTag(TagList.Inventory).GetComponent<ItemDB>();
        _inventory = GameObject.FindGameObjectWithTag(TagList.Inventory).GetComponent<Inventory>();

        foreach (int current in _shopInventory)
        {
            GameObject itemSlotPrefab;
            Text name;
            Text price;
            Image image;
            Item tempItem = _itemDB.FetchItemByID(current);

            // Instatiate slot prefab
            itemSlotPrefab = Instantiate(itemPrefab);
            itemSlotPrefab.transform.SetParent(itemPanel, false);

            // Set Name
            name = itemSlotPrefab.transform.FindChild(TagList.ItemName).GetComponent<Text>();
            name.text = tempItem.Title;
            // Set Price
            price = itemSlotPrefab.transform.FindChild(TagList.ItemPrice).GetComponent<Text>();
            price.text = tempItem.Price.ToString();
            // Set Image
            image = itemSlotPrefab.transform.FindChild(TagList.ItemImage).GetComponent<Image>();
            image.sprite = tempItem.Sprite;

            // Save info into ShopItem
            ShopItem shopItem = itemSlotPrefab.GetComponent<ShopItem>();
            shopItem.item = tempItem;
            shopItem.npc = this;
        }
    }

    public void BuyItem(int id)
    {
        Debug.Log("Purchased itemID: [" + id + "]");
        _inventory.AddItem(id);
    }

}
