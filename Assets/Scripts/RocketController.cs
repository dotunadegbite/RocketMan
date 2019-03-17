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

    public Canvas inventoryCanvas;

    public Text winText;



    // Start is called before the first frame update
    void Start()
    {

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
    }

    public void startRocket()
    {
        flying = true;
        inventoryCanvas.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Debug.Log("rocket moving");
        if (flying)
        {
            updatePosition();
            this.transform.position = Vector3.up * (float)posY + Vector3.right * (float)posX;
            if (isAltitudeIsReached())
            {
                flying = false;
                winText.gameObject.SetActive(true);

            }
        }
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
        Debug.Log(posY + " " + velY + " " + accelerationY);

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
            //stage.fuelWeightPerUnit = fuelType.weight;
            //stage.
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
}
