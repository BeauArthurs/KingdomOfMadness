using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC_Inventory : MonoBehaviour {

    private const string itemName = "Item_Name";
    private const string itemPrice = "Item_Price";

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform itemPanel;
    [SerializeField] private float priceScale = 1f;

    // On interaction(Start for now), load all items into the itemPrefabs.

    void Start()
    {
        foreach (GameObject current in items)
        {
            GameObject tempItemPrefab;
            Text name;
            Text price;

            // Instatiate prefab
            tempItemPrefab = Instantiate(itemPrefab);
            tempItemPrefab.transform.SetParent(itemPanel, false);

            // Set Name
            name = tempItemPrefab.transform.FindChild(itemName).GetComponent<Text>();
            name.text = current.GetComponent<Stats>().name.ToString();
            // Set Price
            price = tempItemPrefab.transform.FindChild(itemPrice).GetComponent<Text>();
            price.text = current.GetComponent<Stats>().price.ToString();

        }
    }

}
