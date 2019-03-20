using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RocketController : MonoBehaviour
{
    List<Stage> stages;
    public double posX, posY, velX, velY, accX, accY;
    bool flying;
    public double targetAltitude;
    double payLoad;
    public double altitude, velocity;
    public double gravity;

    public GameObject completionPanel;

    public UpdateStats updateStats;

    public Sprite oneStageSprite;
    public Sprite twoStageSprite;
    public Sprite threeStageSprite;

    private SpriteRenderer renderer;

    public TMP_Text completionText;

    //public CompletionPopupScript completionPopupScript;

    FuelType currentFuelType;
    FuelTank currentFuelTank;
    RocketConfiguration currentRocketConfiguration;

    // Start is called before the first frame update
    void Start()
    {
        gravity = Math.Round(UnityEngine.Random.Range(4f, 20f),2);



        renderer = this.GetComponent<SpriteRenderer>();
        updateStats = FindObjectOfType<UpdateStats>();

        targetAltitude = Math.Round(UnityEngine.Random.Range(1000f, 5000f),0); ; // in km
        payLoad = Math.Round(UnityEngine.Random.Range(1f,70f),2); //In kg
        //Let's do this metric

        Debug.Log("rocket starting");
        flying = false;
        stages = new List<Stage>();
        stages.Add(new Stage(0, "stage 1", "stage 1", null, null, 100, 10.0D / 60, 100, 100, 1000, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            posX -= 0.1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            posX += 0.1;
        }
        /*
        else if (Input.GetKey(KeyCode.Space))
        {
            startRocket();
        }*/

        if (currentRocketConfiguration != null)
        {
            renderer.enabled = true;
            Debug.Log(currentRocketConfiguration.numStages);
            switch (currentRocketConfiguration.numStages)
            {
                case 1:
                    renderer.sprite = oneStageSprite;
                    break;
                case 2:
                    renderer.sprite = twoStageSprite;
                    break;
                case 3:
                    renderer.sprite = threeStageSprite;
                    break;
            }
        } else {
            renderer.enabled = false;
        }
    }

    public void startRocket()
    {
        flying = true;
    }

    void FixedUpdate()
    {
        if (flying)
        {
            updatePosition();
            this.transform.position = Vector3.up * (float)posY + Vector3.right * (float)posX;
            if (isAltitudeIsReached())
            {
                hasWon();

            }
        }
        if(velocity<0)
        {
            hasLost();
        }
    }

    void hasWon()
    {
        completionText.text = "Yay!";
        updateStats.hasWon = true;
        flying = false;
        completionPanel.gameObject.SetActive(true);
    }

    void hasLost()
    {
        completionText.text = "No!";
        flying = false;
        completionPanel.gameObject.SetActive(true);
    }


    void updatePosition() {
        double currentWeight = getWeight();

        double thrustForce = 0;
        if (stages.Count > 0) {

            Stage lastStage = stages[stages.Count - 1];
            thrustForce = lastStage.generateThrustForce();
            if (lastStage.isEmpty)
            {
                stages.RemoveAt(stages.Count - 1);
            }
        }

        double accelerationY = thrustForce / currentWeight +
                               getGravityAcceleration() * Time.deltaTime +
                               getAirResistanceAcceleration(velY) * Time.deltaTime;

        velY += accelerationY;
        posY += velY * Time.deltaTime;
        posY = posY > 0 ? posY : 0.0D;

        // wind
        altitude = posY;
        velocity = velY;
    }

    void addStage(Stage stage) {
        stages.Add(stage);
    }

    double getGravityAcceleration()
    {
        return -gravity;
    }

    double getAirResistanceAcceleration(double velocity)
    {

        return (velocity > 0 ? -1 : +1) * 0.001*velocity*velocity; // TODO
    }

    public void updateComponent(Item item)
    {

    }

    bool isAltitudeIsReached()
    {
        return altitude >= targetAltitude;
    }

    public void setFuelType(FuelType fuelType)
    {
        foreach(Stage stage in stages)
        {
            stage.fuelWeightPerUnit = fuelType.weight;
            stage.fuelAcceleration = fuelType.acceleration;
        }
        currentFuelType = fuelType;
    }

    public void setFuelTank(FuelTank tank)
    {
        foreach (Stage stage in stages)
        {
            stage.tankWeight = tank.weight;
        }
        currentFuelTank = tank;
    }

    public void setRocketConfiguration(RocketConfiguration config)
    {
        currentRocketConfiguration = config;
        stages.Clear();
        for(int stage = 0; stage < config.numStages; stage++)
        {
            stages.Add(new Stage(
                0, "", "", null, null,
                config.fuelCapacities[stage], config.burnRates[stage], config.fuelCapacities[stage],
                config.weights[stage],
                0, 0));
        }
        if (currentFuelTank != null)
        {
            setFuelTank(currentFuelTank);
        }

        if (currentFuelType != null)
        {
            setFuelType(currentFuelType);
        }
    }


    public double getVelocity()
    {
        return velY;
    }

    public double getAltitude()
    {
        return posY;
    }

    public double getGravity()
    {
        return gravity;
    }

    public double getWeight()
    {
        double currentWeight = payLoad;
        foreach (Stage stage in stages)
        {
            currentWeight += stage.getTotalWeight();
        }
        return currentWeight;
    }

    public double getCost()
    {
        double currentCost = 0;
        if(currentFuelTank != null)
        {
            currentCost += currentFuelTank.cost;
        }

        if (currentFuelType != null)
        {
            currentCost += currentFuelType.cost;
        }

        if (currentRocketConfiguration != null)
        {
            currentCost += currentRocketConfiguration.cost;
        }

        return currentCost;
    }

    public double getTargetAltitude()
    {
        return targetAltitude;
    }

    public double getPayload()
    {
        return payLoad;
    }

    public FuelTank getCurrentFuelTank()
    {
        return currentFuelTank;
    }

    public FuelType getCurrentFuelType()
    {
        return currentFuelType;
    }

    public RocketConfiguration getCurrentRocketConfiguration()
    {
        return currentRocketConfiguration;
    }
}
