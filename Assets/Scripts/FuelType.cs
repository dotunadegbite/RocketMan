﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelType : Item
{
    public int acceleration;
    public int weight;
    public int volatility;

    public FuelType(int id, string title, string description, string icon, Dictionary<string, int> stats) : base(id, title, description, icon, stats)
    {
        this.acceleration = stats["acceleration"];
        this.weight = stats["weight"];
        this.volatility = stats["volatility"];
    }
}