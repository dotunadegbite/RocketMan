using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : Item
{
    public int fuelCapacity;
    public int burnRate;

    public Stage(int id, string title, string description, Sprite icon, Dictionary<string, int> stats, int fuelCapacity, int burnRate) : base(id, title, description, icon, stats)
    {
        this.fuelCapacity = fuelCapacity;
        this.burnRate = burnRate;
    }

    public Stage(Stage other) : base(other)
    {
        this.fuelCapacity = other.fuelCapacity;
        this.burnRate = other.burnRate;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
