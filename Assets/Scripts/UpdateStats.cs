using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    // TMP_Text statsText;
    public TMP_Text velocityText;
    public TMP_Text currentAltitudeText;
    public TMP_Text gravityText;
    public TMP_Text payloadText;
    public TMP_Text targetAltitudeText;

    public RocketController rocket;
    // Start is called before the first frame update
    void Start()
    {
        //rocket = FindObjectOfType<RocketController>();

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
}