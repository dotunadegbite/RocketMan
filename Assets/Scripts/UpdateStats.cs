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
        targetAltitudeText, fuelTypeText, fuelTankText, stagesText, weightText, costText, currentMoney;

    public Image itemIcon1, itemIcon2, itemIcon3;

    public RocketController rocket;

    private ItemDatabase db;

    private StoreItem item1, item2, item3;

    public bool hasWon;

    public Wallet wallet;

   

    // Use this for initialization
    /*private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            this.wallet.setCash(10000);
        }
        else
        {
            Debug.Log("Destroy mamager");
            Destroy(this);
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        this.db = GetComponent<ItemDatabase>();
        this.wallet = GameObject.Find("Wallet").GetComponent<Wallet>();
        this.itemIcon1.enabled = false;
        this.itemIcon2.enabled = false;
        this.itemIcon3.enabled = false;

        this.item1 = this.itemIcon1.GetComponent<StoreItem>();
        this.item2 = this.itemIcon2.GetComponent<StoreItem>();
        this.item3 = this.itemIcon3.GetComponent<StoreItem>(); 
        hasWon = false;
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
        this.currentMoney.text = "Cash balance: $" + wallet.getCash();




    }
    public void LoadStoreItems(int itemType)
    {
        if (itemType == 0)
        {
            this.itemIcon1.sprite = this.db.fuelTypes[0].icon;
            this.item1.Setup(this.db.fuelTypes[0],itemType, this.db.fuelTypes[0]);

            this.itemIcon2.sprite = this.db.fuelTypes[1].icon;
            this.item2.Setup(this.db.fuelTypes[1], itemType, this.db.fuelTypes[1]);

            this.itemIcon3.sprite = this.db.fuelTypes[2].icon;
            this.item3.Setup(this.db.fuelTypes[2], itemType, this.db.fuelTypes[2]);
        }
        else if (itemType == 1)
        {
            this.itemIcon1.sprite = this.db.fuelTanks[0].icon;
            this.item1.Setup(this.db.fuelTanks[0], itemType,null, this.db.fuelTanks[0]);

            this.itemIcon2.sprite = this.db.fuelTanks[1].icon;
            this.item2.Setup(this.db.fuelTanks[1], itemType, null, this.db.fuelTanks[1]);

            this.itemIcon3.sprite = this.db.fuelTanks[2].icon;
            this.item3.Setup(this.db.fuelTanks[2], itemType, null, this.db.fuelTanks[2]);
        }
        else if (itemType == 2)
        {
            this.itemIcon1.sprite = this.db.rocketConfigurations[0].icon;
            this.item1.Setup(this.db.rocketConfigurations[0], itemType, null, null, this.db.rocketConfigurations[0]);

            this.itemIcon2.sprite = this.db.rocketConfigurations[1].icon;
            this.item2.Setup(this.db.rocketConfigurations[1], itemType, null, null, this.db.rocketConfigurations[1]);

            this.itemIcon3.sprite = this.db.rocketConfigurations[2].icon;
            this.item3.Setup(this.db.rocketConfigurations[2], itemType, null, null, this.db.rocketConfigurations[2]);
        }

        this.itemIcon1.enabled = true;
        this.itemIcon2.enabled = true;
        this.itemIcon3.enabled = true;
    }

}