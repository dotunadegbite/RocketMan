using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public Item GetItem(int id)
    {
        return this.items.Find(item => item.id == id);
    }
    private void Awake()
    {
        this.BuildDatabase();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildDatabase()
    {
        this.items = new List<Item>()
        {
            new Stage(0, "First Stage", "Initial rocket", null, 
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"weight", 10 }
            },
            100, 10.0D / 60, 100, 100, 1000, 1)
        };
    }
}
