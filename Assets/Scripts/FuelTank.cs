using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : Item
{
    public int safety;
    public int weight;

    public FuelTank(int id, string title, string description, Sprite icon, Dictionary<string, int> stats) :base(id, title, description, icon, stats){
        this.safety = stats["safety"];
        this.weight = stats["weight"];
    }
}
