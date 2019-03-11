﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    public Text statsText;
    RocketController rocket;
    // Start is called before the first frame update
    void Start()
    {
        rocket = FindObjectOfType<RocketController>();
    }

    // Update is called once per frame
    void Update()
    {
        statsText.text = "Speed: " + Math.Round(rocket.velocity, 2)  + "km/h \nAltitude: " + Math.Round(rocket.alititude, 2)+"km ";  
    }
}