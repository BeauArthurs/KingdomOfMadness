using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDB : MonoBehaviour
{
    private List<Item> _database = new List<Item>();
    private JsonData _itemData;

    void Start()
    {
        _itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDB();

        //Debug.Log(_database[1].Power);
        Debug.Log(FetchItemByID(1).Description);
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i< _database.Count; i++)
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
                (int)_itemData[i]["value"],
                (int)_itemData[i]["stats"]["power"],
                (int)_itemData[i]["stats"]["defence"],
                (int)_itemData[i]["stats"]["vitality"],
                _itemData[i]["description"].ToString(),
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
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int value, int power, int defence, int vitality, string description, bool stackable, int rarity, string slug)
    {
        ID = id;
        Title = title;
        Value = value;
        Power = power;
        Defence = defence;
        Vitality = vitality;
        Description = description;
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