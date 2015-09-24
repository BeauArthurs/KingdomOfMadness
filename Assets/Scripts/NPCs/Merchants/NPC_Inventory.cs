using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC_Inventory : MonoBehaviour
{

    private const string ITEM_NAME  = "Item_Name";
    private const string ITEM_PRICE = "Item_Price";
    private const string ITEM_IMAGE = "Item_Image";

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int[] _shopInventory;
    [SerializeField] private Transform itemPanel;
    [SerializeField] private float priceScale = 1f;

    private ItemDB _itemDB;

    // On interaction (Start for now), load all items into the itemPrefabs.

    void Start()
    {
        _itemDB = GameObject.FindGameObjectWithTag("Inventory").GetComponent<ItemDB>();

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
            name = itemSlotPrefab.transform.FindChild(ITEM_NAME).GetComponent<Text>();
            name.text = tempItem.Title;
            // Set Price
            price = itemSlotPrefab.transform.FindChild(ITEM_PRICE).GetComponent<Text>();
            price.text = tempItem.Price.ToString();
            // Set Image
            image = itemSlotPrefab.transform.FindChild(ITEM_IMAGE).GetComponent<Image>();
            image.sprite = tempItem.Sprite;
        }
    }

}
