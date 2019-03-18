using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchScript : MonoBehaviour
{
    private RocketController rocket;
    public Button launchButton;
    // Start is called before the first frame update
    void Start()
    {
        rocket = FindObjectOfType<RocketController>();
        this.launchButton.interactable = false;
        //this.GetComponent<>
    }

    private void Update()
    {
        if (this.CheckRocketParts())
        {
            Debug.Log("Does this work");
            this.launchButton.interactable = true;
        }
            
    }

    public void onClickLaunch() 
    {

        rocket.startRocket();
        this.gameObject.SetActive(false);

    }

    private bool CheckRocketParts()
    {
        bool hasFuel = this.rocket.getCurrentFuelType() != null;
        bool hasTank = this.rocket.getCurrentFuelTank() != null;
        bool hasConfig = this.rocket.getCurrentRocketConfiguration() != null;


        return hasConfig && hasTank && hasFuel;
    }


}
