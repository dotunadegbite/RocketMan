using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : Item
{
    public int safetyLevel;

    // Start is called before the first frame update
    public FuelTank(int id, string title, string description, Sprite icon, Dictionary<string, int> stats, int safetyLevel) :base(id, title, description, icon, stats){
        this.safetyLevel = safetyLevel;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
