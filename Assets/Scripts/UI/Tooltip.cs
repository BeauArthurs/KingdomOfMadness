using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Boy Voesten

// TODO:
//  Use seperate text components to align strings correctly

public class Tooltip : MonoBehaviour {

    private Item _item;
    private string _data;
    private GameObject _tooltipObj;

    void Start() 
    {
        _tooltipObj = GameObject.FindGameObjectWithTag("Tooltip");
        _tooltipObj.SetActive(false);
    }

    void Update() 
    {
        if (_tooltipObj.activeSelf) 
        {
            _tooltipObj.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item) 
    {
        _item = item;
        ConstructDataString();
        _tooltipObj.SetActive(true);
    }

    public void Deactivate() 
    {
        _tooltipObj.SetActive(false);
    }

    public void ConstructDataString() 
    {
        string color = "#FFFFFF";
        switch (_item.Rarity) {
            //Legendary Quality (Orange)
            case 0:
                color = "#FFA500";
                break;
            //Epic Quality (Purple)
            case 1:
                color = "#FF00FF";
                break;
            //Rare Quality (Blue)
            case 2:
                color = "#1E90FF";
                break;
            //Uncommon Quality (Green)
            case 3:
                color = "#32CD32";
                break;
            //Common Quality (White)
            case 4:
                color = "#FFFFFF";
                break;
            //Poor Quality (Grey) 
            case 5:
                color = "#A9A9A9";
                break;
            default:
                break;
        }
        _data = "<color=" + color + "><b>" + _item.Title + "</b></color>" +
            "\n" + _item.WieldingStyle + "                           " + _item.Type +
            "\n\nStats" +
            "\n Damage: " + _item.Damage +
            "\n Speed: " + _item.Speed +
            "\n Crit Chance: " + _item.CritChance +
            "\n\n<color=#A9A9A9><i>" + _item.Description + "</i></color>" +
        "\nSell Price: " + _item.Price;
        _tooltipObj.transform.GetChild(0).GetComponent<Text>().text = _data;
    }
}
