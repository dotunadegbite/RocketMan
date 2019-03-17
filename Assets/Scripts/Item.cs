using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string title;
    public string description;
    public int cost;
    public Sprite icon;
    public bool beenPurchased = false;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string title, string description, string iconName, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + iconName);
        this.stats = stats;
        this.cost = stats["cost"];
    }
    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = item.icon;
        this.stats = item.stats;
        this.cost = stats["cost"];
    }
}
