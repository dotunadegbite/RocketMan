using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketConfiguration : Item
{
    public int numStages;
    public int weights;
    public int fuelCapacity;
    public int burnRates;

    public RocketConfiguration(int id, string title, string description, Sprite icon, Dictionary<string, int> stats) : base(id, title, description, icon, stats)
    {
        this.numStages = stats["numStages"];
        this.weights = stats["weights"];
        this.fuelCapacity = stats["fuelCapacity"];
        this.burnRates = stats["burnRates"];
    }
}
