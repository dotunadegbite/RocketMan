using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour
{
    List<Stage> stages;
    public double posX, posY, velX, velY, accX, accY;
    bool flying;
    public double targetAltitude;
    double payLoad;
    public double altitude, velocity;
    public double gravity = 9.8;

    public GameObject completionPanel;

    public UpdateStats updateStats;

    public Text winText;

    public Sprite oneStageSprite;
    public Sprite twoStageSprite;
    public Sprite threeStageSprite;

    FuelType currentFuelType;
    FuelTank currentFuelTank;
    RocketConfiguration currentRocketConfiguration;

    // Start is called before the first frame update
    void Start()
    {
        updateStats = FindObjectOfType<UpdateStats>();
        winText.gameObject.SetActive(false);

        //These should be set semi randomly, depending on gravity and mission
        targetAltitude = 2000.0d; // in km
        payLoad = 10.0d; //In kg
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
            Debug.Log(currentRocketConfiguration.numStages);
            switch (currentRocketConfiguration.numStages)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = oneStageSprite;
                    break;
                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = twoStageSprite;
                    break;
                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = threeStageSprite;
                    break;
            }
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
        updateStats.hasWon = true;
        flying = false;
        completionPanel.gameObject.SetActive(true);
    }

    void hasLost()
    {
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
