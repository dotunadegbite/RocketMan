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
                {"fuelCaoacity", 100 },
                {"burnRate", 2}
            },
            100, 10.0D / 60, 100, 100, 1000, 1),

            new Stage(0, "Second Stage", "Initial rocket", null,
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"fuelCaoacity", 200 },
                {"burnRate", 4}
            },
            100, 10.0D / 60, 100, 100, 1000, 1),

            new Stage(0, "First Stage", "Initial rocket", null,
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"fuelCaoacity", 300 },
                {"burnRate", 6}
            },
            100, 10.0D / 60, 100, 100, 1000, 1),

            new Stage(0, "Third Stage", "Initial rocket", null,
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"weight", 10 }
            },
            100, 10.0D / 60, 100, 100, 1000, 1),

            new FuelTank(0, "Unsafe", "Initial rocket", null,
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"weight", 30 }
            },
            1),

            new FuelTank(0, "Safe", "Initial rocket", null,
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"weight", 60 }
            },
            1),
            new FuelType(0, "Volatile", "Initial rocket", null,
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"accelerationPerUnitVolume", 1000 }
            },
            1),
            new FuelType(0, "Unsafe", "Initial rocket", null,
            new Dictionary<string, int>()
            {
                { "cost", 0 },
                {"accelerationPerUnitVolume", 2000 }
            },
            1)
        };
    }
}
