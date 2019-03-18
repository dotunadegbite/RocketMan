using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItem : MonoBehaviour
{

    public Item currentItem;
    public RocketConfiguration currentConfig;
    public FuelTank currentTank;
    public FuelType currentType;
    public int itemType;
    public TMP_Text description, cost, fuelTankText, fuelTypeText, stagesText, costText, weightText;
    public GameObject textPrefab;
    public List<TMP_Text> textHolders;
    public RocketController rocket;

    private List<GameObject> createdStats;

    // Start is called before the first frame update
    void Start()
    {
        this.description.enabled = false;
        this.cost.enabled = false;
        this.createdStats = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Item item, int itemType, FuelType fuel=null, FuelTank tank=null, RocketConfiguration config=null)
    {
        this.currentItem = item;
        this.itemType = itemType;

        
        switch (this.itemType)
        {
            case 0:
                this.currentType = fuel;
                break;
            case 1:
                this.currentTank = tank;
                break;
            case 2:
                this.currentConfig = config;
                break;
            default:
                break;

        }
        
    }

    public void ShowDescription()
    {
        foreach (TMP_Text text in this.textHolders)
            text.enabled = false;

        this.description.text = this.currentItem.description;
        this.cost.text = "$" + this.currentItem.cost;

        this.description.enabled = true;
        this.cost.enabled = true;

        List<string> stats = new List<string>(this.currentItem.stats.Keys);

        for(int i = 0; i < stats.Count; i++)
        {

            TMP_Text statText = this.textHolders[i];
            statText.text = stats[i] + ": " + this.currentItem.stats[stats[i]];
            statText.enabled = true;
            
        }

        switch (this.itemType)
        {
            case 0:
                this.fuelTypeText.text = this.currentType != null ? "Fuel Type: " + this.currentType.title : "Fuel Type: ";
                break;

            case 1:
                this.fuelTankText.text = this.currentTank != null ? "Fuel Tank: " + this.currentTank.title : "Fuel Tank: ";
                break;

            case 2:
                this.stagesText.text = this.currentConfig != null ? "Number of stages: " + this.currentConfig.numStages : "Number of stages: ";
                break;
        }


        EquipRocketParts();

        this.costText.text = "Total cost: $" + this.rocket.getCost();
        this.weightText.text = "Total weight: " + this.rocket.getWeight() + "kg";

    }

    public void EquipRocketParts()
    {
        Debug.Log("running " + this.itemType);

        switch (this.itemType)
        {
            case 0:
                this.rocket.setFuelType((FuelType)this.currentItem);

                break;

            case 1:
                this.rocket.setFuelTank((FuelTank)this.currentItem);

                break;

            case 2:
                this.rocket.setRocketConfiguration((RocketConfiguration)this.currentItem);

                break;
        }
        /*
        if (this.currentType != null)
            this.rocket.setFuelType((FuelType)this.currentItem);
        else if (this.currentTank != null)
        {
            Debug.Log(this.currentTank.cost);
            this.rocket.setFuelTank((FuelTank)this.currentItem);
        }

        else if (this.currentConfig != null)
        {
            this.rocket.setRocketConfiguration((RocketConfiguration)this.currentItem);
            Debug.Log("equip: " + this.currentConfig.numStages);
        }*/
    }
}
