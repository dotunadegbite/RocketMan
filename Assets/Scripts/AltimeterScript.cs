using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltimeterScript : MonoBehaviour
{

    public float xCoord, yCoord;
    private double targetAltitude, currentAltitude;
    public Texture backgroundTexture, fillTexture;
    RocketController rocket;

    private void Start()
    {
        rocket = FindObjectOfType<RocketController>();
        targetAltitude = rocket.getTargetAltitude();
    }

    private void OnGUI()
    {
        float topFillEdge = (float)(200 * (rocket.getTargetAltitude() - rocket.getAltitude()) / rocket.getTargetAltitude());

        float boxHeight = 250;

        GUIStyle style = new GUIStyle();

        style = GUIStyle.none;

        //style.fixedWidth = 30;
        style.stretchWidth = true;



        GUI.BeginGroup(new Rect(xCoord, yCoord, 250, boxHeight));
        GUI.Label(new Rect(20, 0, 200, 20), "Target Altitude: "+ rocket.getTargetAltitude() + " m");
        GUI.Label(new Rect(20, topFillEdge+10, 200, 20), "Current Altitude: " + Math.Round(rocket.getAltitude(),2)+" m");

        // Draw a box in the new coordinate space defined by the BeginGroup.
        // Notice how (0,0) has now been moved on-screen
        GUI.backgroundColor = Color.black;
        GUI.Box(new Rect(0, 10, 15, 200), backgroundTexture, style);
        GUI.backgroundColor = Color.green;
        GUI.Box(new Rect(0, topFillEdge+10, 15, 200- topFillEdge), fillTexture, style);



        // We need to match all BeginGroup calls with an EndGroup
        GUI.EndGroup();
    }

    // Update is called once per frame
    void Update()
    {
        currentAltitude = rocket.getAltitude();
        //Debug.Log("Target Altitude: " + rocket.getTargetAltitude());
    }
}
