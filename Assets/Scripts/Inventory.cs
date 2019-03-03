using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase database;

    public void GiveItem(int id)
    {
        Item newItem = database.GetItem(id);
        this.characterItems.Add(newItem);
        Debug.Log("Gave the rocket: " + newItem.title);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GiveItem(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
