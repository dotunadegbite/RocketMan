using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketConfiguration : Item
{
    public int numStages;
    public List<double> weights;
    public List<double> fuelCapacities;
    public List<double> burnRates;

    public RocketConfiguration(int id, string title, string description, string iconName, Dictionary<string, int> stats, List<double> weights, List<double> fuelCapacities, List<double> burnRates) : base(id, title, description, iconName, stats)
    {
        this.numStages = stats["numStages"];
        this.weights = weights;
        this.fuelCapacities = fuelCapacities;
        this.burnRates = burnRates;
    }
}
