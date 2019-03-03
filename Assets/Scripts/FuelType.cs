using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelType : Item 
{
    public int safetyLevel;

    public FuelType(int id, string title, string description, Sprite icon, Dictionary<string, int> stats, int safetyLevel) : base(id, title, description, icon, stats)
    {
        this.safetyLevel = safetyLevel;
    }
}
