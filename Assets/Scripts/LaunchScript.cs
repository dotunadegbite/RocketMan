using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchScript : MonoBehaviour
{
    private RocketController rocket;
    public Button launchButton;
    public Wallet wallet;

    public GameObject rocketStats, menu, itemInfo;
    // Start is called before the first frame update
    void Start()
    {
        rocket = FindObjectOfType<RocketController>();
        this.launchButton.interactable = false;
        //this.GetComponent<>
        this.wallet = GameObject.Find("Wallet").GetComponent<Wallet>();
    }

    private void Update()
    {
        if (this.CheckRocketParts())
        {
            //Debug.Log("Does this work");
            this.launchButton.interactable = true;
        }
            
    }

    public void onClickLaunch() 
    {
        int remainingCash = this.wallet.getCash() - (int)this.rocket.getCost();
        if(remainingCash >= 0)
        {
            rocket.startRocket();
            //this.rocketStats.SetActive(false);
            this.itemInfo.SetActive(false);
            this.menu.SetActive(false);

            this.wallet.setCash(remainingCash);

            this.gameObject.SetActive(false);
        }

    }

    private bool CheckRocketParts()
    {
        bool hasFuel = this.rocket.getCurrentFuelType() != null;
        bool hasTank = this.rocket.getCurrentFuelTank() != null;
        bool hasConfig = this.rocket.getCurrentRocketConfiguration() != null;


        return hasConfig && hasTank && hasFuel;
    }


}
