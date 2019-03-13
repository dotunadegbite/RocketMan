using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{
    private RocketController rocket;
    // Start is called before the first frame update
    void Start()
    {
        rocket = FindObjectOfType<RocketController>();
    }

    public void onClickLaunch() 
    {

        rocket.startRocket();

    }


}
