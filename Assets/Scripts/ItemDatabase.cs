﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    public List<FuelTank> fuelTanks = new List<FuelTank>();
    public List<FuelType> fuelTypes = new List<FuelType>();
    public List<RocketConfiguration> rocketConfigurations = new List<RocketConfiguration>();

    public Item GetItem(int id)
    {
        return this.items.Find(item => item.id == id);
    }


    private void Awake()
    {
        this.BuildDatabase();
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void BuildDatabase()
    {
        this.fuelTanks = new List<FuelTank>()
        {
            new FuelTank(1, "Small Tank", "Small and cheap", "tankOne",
                         new Dictionary<string, int>{{"safety",1}, {"weight",30}, {"cost", 800}}),
            new FuelTank(2, "Medium Tank", "Average", "tankTwo",
                         new Dictionary<string, int>{{"safety",2}, {"weight",60}, {"cost", 1100}}),
            new FuelTank(3, "Large Tank", "Large and expensive", "tankThree",
                         new Dictionary<string, int>{{"safety",3}, {"weight",90}, {"cost", 1400}})
        };

        this.fuelTypes = new List<FuelType>()
        {
            new FuelType(4, "Inefficient Fuel", "Cheap but inefficient", "fuelOne",
                         new Dictionary<string, int>{{"acceleration",1000}, {"weight",1}, { "volatility", 1}, {"cost",400}}),
            new FuelType(5, "Standard Fuel", "Average", "fuelTwo",
                         new Dictionary<string, int>{{ "acceleration", 2000}, { "weight", 1 }, {"volatility", 2}, {"cost", 700}}),
            new FuelType(6, "Efficient Fuel", "Efficient and expensive", "fuelThree",
                         new Dictionary<string, int>{{ "acceleration", 3000}, { "weight", 1 }, {"volatility", 3}, {"cost", 1000}})
        };

        this.rocketConfigurations = new List<RocketConfiguration>()
        {
            new RocketConfiguration(7, "One Stage Rocket", "Only has one stage", "stageOne",
                                    new Dictionary<string, int>{{"numStages",1},{"cost", 1100}},  new List<double>(){100},  new List<double>(){100},  new List<double>(){0.2}),
            new RocketConfiguration(8, "Two Stage Rocket", "Has a second stage but is more expensive", "stageTwo",
                                    new Dictionary<string, int>{{"numStages",2},{"cost", 1400 }}, new List<double>(){100,100},  new List<double>(){100,200},  new List<double>(){0.2,0.2}),
            new RocketConfiguration(9, "Three Stage Rocket", "Most stages, most expensive", "stageThree",
                         new Dictionary<string, int>{{"numStages",3}, {"cost", 1700 }},  new List<double>(){100,100,100},  new List<double>(){100,200,300},  new List<double>(){0.2,0.2,0.2})
        };

        items.AddRange(fuelTanks);
        items.AddRange(fuelTypes);
        items.AddRange(rocketConfigurations);

    }
}
