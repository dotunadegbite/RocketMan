using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltimeterScript : MonoBehaviour
{

    public float xCoord, yCoord;
    private void OnGUI()
    {
        // Constrain all drawing to be within a 800x600 pixel area centered on the screen.
        GUI.BeginGroup(new Rect(xCoord, yCoord, 300, 300));

        // Draw a box in the new coordinate space defined by the BeginGroup.
        // Notice how (0,0) has now been moved on-screen
        GUI.Box(new Rect(0, 0, 800, 600), "This box is now centered! - here you would put your main menu");

        // We need to match all BeginGroup calls with an EndGroup
        GUI.EndGroup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
