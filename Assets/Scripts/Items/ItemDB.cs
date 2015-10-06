using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

// Boy Voesten

// TODO:
//  Make the items potion and armor friendly (currently only focussed on Weapon items)

public class ItemDB : MonoBehaviour
{
    private List<Item> _database = new List<Item>();
    private JsonData _itemData;

    void Start()
    {
        _itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDB();
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < _database.Count; i++)
            if (_database[i].ID == id)
                return _database[i];
        return null;
    }

    void ConstructItemDB()
    {
        for (int i = 0; i < _itemData.Count; i++)
        {
            _database.Add(new Item(
                    (int)_itemData[i]["id"], 
                    _itemData[i]["title"].ToString(),
                    _itemData[i]["description"].ToString(),
                    (int)_itemData[i]["price"],
                    _itemData[i]["type"].ToString(),
                    _itemData[i]["wieldingstyle"].ToString(),
                    (int)_itemData[i]["stats"]["damage"]/10f,
                    (int)_itemData[i]["stats"]["speed"]/10f,
                    (int)_itemData[i]["stats"]["critchance"]/10f,
                    (int)_itemData[i]["weight"]/10f,
                    (bool)_itemData[i]["stackable"],
                    (int)_itemData[i]["rarity"],
                    _itemData[i]["slug"].ToString()
                )
            );
            
        }
    }

}

public class Item
{
    // Properties
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Type { get; set; }
    public string WieldingStyle { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float CritChance { get; set; }
    public float Weight { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, string description, int price, string type, string wieldingstyle, float damage, float speed, float critchance, float weight, bool stackable, int rarity, string slug)
    {
        ID = id;
        Title = title;
        Description = description;
        Price = price;
        Type = type;
        WieldingStyle = wieldingstyle;
        Damage = damage;
        Speed = speed;
        CritChance = critchance;
        Weight = weight;
        Stackable = stackable;
        Rarity = rarity;
        Slug = slug;

        Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public Item()
    {
        ID = -1;
    }
}