using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    // TMP_Text statsText;
    public TMP_Text velocityText, currentAltitudeText, gravityText, payloadText, 
        targetAltitudeText, fuelTypeText, fuelTankText, stagesText, weightText, costText;

    public Image itemIcon1, itemIcon2, itemIcon3;

    public RocketController rocket;

    private ItemDatabase db;
    // Start is called before the first frame update
    void Start()
    {
        //rocket = FindObjectOfType<RocketController>();
        this.db = GetComponent<ItemDatabase>();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshDisplay();   
    }

    private void RefreshDisplay()
    {
        this.velocityText.text = "Speed: " + Math.Round(this.rocket.getVelocity(), 2) + "m/s";
        this.currentAltitudeText.text = "Altitude: " + Math.Round(this.rocket.getAltitude(), 2) + "m ";
        this.gravityText.text = "Current Gravity: " + this.rocket.getGravity() + "m/s";
        this.payloadText.text = "Payload Weight: " + this.rocket.getPayload() + "kg";
        this.targetAltitudeText.text = "Target Altitude " + this.rocket.getTargetAltitude() + "m";

    }

    public void LoadStoreItems(int itemType)
    {
        
        if(itemType == 0)
        {
            Debug.Log(itemType);
            this.itemIcon1.sprite = this.db.fuelTypes[0].icon;
            this.itemIcon2.sprite = this.db.fuelTypes[1].icon;
            this.itemIcon3.sprite = this.db.fuelTypes[2].icon;
        }
        else if (itemType == 1)
        {
            this.itemIcon1.sprite = this.db.fuelTanks[0].icon;
            this.itemIcon2.sprite = this.db.fuelTanks[1].icon;
            this.itemIcon3.sprite = this.db.fuelTanks[2].icon;
        }
        else if (itemType == 2)
        {
            this.itemIcon1.sprite = this.db.rocketConfigurations[0].icon;
            this.itemIcon2.sprite = this.db.rocketConfigurations[1].icon;
            this.itemIcon3.sprite = this.db.rocketConfigurations[2].icon;
        }
    }
}