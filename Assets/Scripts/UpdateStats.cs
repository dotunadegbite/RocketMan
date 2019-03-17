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

    public RocketController rocket;


    public bool hasWon;

    public Wallet wallet;

    // Start is called before the first frame update
    void Start()
    {
        //rocket = FindObjectOfType<RocketController>();
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

}