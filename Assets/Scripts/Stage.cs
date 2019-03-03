    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : Item
{
    public double fuelCapacity;
    public double burnRate;
    public double fuelRemaining, baseWeight, fuelAcceleration, fuelWeightPerUnit;
    public bool isEmpty;

    public Stage(
        int id, string title, string description, Sprite icon, Dictionary<string, int> stats,
        double fuelCapacity, double burnRate, double fuelRemaining, double baseWeight, double fuelAcceleration, double fuelWeightPerUnit) :
        base(id, title, description, icon, stats)
    {
        this.fuelCapacity = fuelCapacity;
        this.burnRate = burnRate;
        this.fuelRemaining = fuelRemaining;
        this.baseWeight = baseWeight;
        this.fuelAcceleration = fuelAcceleration;
        this.fuelWeightPerUnit = fuelWeightPerUnit;
        this.isEmpty = false;
    }

    public Stage(Stage other) : base(other)
    {
        this.fuelCapacity = other.fuelCapacity;
        this.burnRate = other.burnRate;
        this.fuelRemaining = other.fuelRemaining;
        this.baseWeight = other.baseWeight;
        this.fuelAcceleration = other.fuelAcceleration;
        this.fuelWeightPerUnit = other.fuelWeightPerUnit;
        this.isEmpty = other.isEmpty;
    }

    public double getTotalWeight()
    {
        return baseWeight + fuelRemaining * fuelWeightPerUnit;
    }

    public double generateThrustForce()
    {
        double fuelBurned;
        if(fuelRemaining < burnRate)
        {
            fuelBurned = fuelRemaining;
            isEmpty = true;
        }
        else
        {
            fuelBurned = burnRate;
        }

        fuelRemaining -= fuelBurned;
        return fuelBurned * fuelAcceleration;
    }
}
