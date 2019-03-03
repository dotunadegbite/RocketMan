using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelType : Item 
{
    public int safetyLevel;

    public FuelType(int id, string title, string description, Sprite icon, Dictionary<string, int> stats, int safetyLevel)
    {
        this.safetyLevel = safetyLevel;
    }

    public FuelType(FuelType fuelType) : base(other)
    {
        this.safetyLevel = safetyLevel;
    }
}
