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

        GUI.BeginGroup(new Rect(xCoord, yCoord, 300, 300));

        // Draw a box in the new coordinate space defined by the BeginGroup.
        // Notice how (0,0) has now been moved on-screen
        GUI.Box(new Rect(250, 0, 50, 300), backgroundTexture);
        GUI.Box(new Rect(250, (float)(300 * (targetAltitude - currentAltitude) / targetAltitude), 50, 300- (float)(300 * (targetAltitude - currentAltitude) / targetAltitude)), fillTexture);



        // We need to match all BeginGroup calls with an EndGroup
        GUI.EndGroup();
    }

    // Update is called once per frame
    void Update()
    {
        currentAltitude = rocket.getAltitude();
    }
}
