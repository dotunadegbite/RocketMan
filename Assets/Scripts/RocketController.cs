using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour
{
    List<Stage> stages;
    double posX, posY, velX, velY, accX, accY;
    bool flying;
    public double targetHeight;
    double payLoad;
    public double alititude;
    public double velocity;



    // Start is called before the first frame update
    void Start()
    {
        //These should be set semi randomly, depending on gravity and mission
        targetHeight = 120.0d; // in km
        payLoad = 4000.0d; //In kg
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
        else if (Input.GetKey(KeyCode.Space))
        {
            startRocket();
        }
    }

    void startRocket()
    {
        flying = true;
        targetHeight = 100;
    }

    void FixedUpdate()
    {
        Debug.Log("rocket moving");
        if (flying)
        {
            updatePosition();
            this.transform.position = Vector3.up * (float)posY + Vector3.right * (float)posX;
            if(this.posY > targetHeight)
            {
                flying = false;
            }
        }
    }

    void updatePosition() {
        double currentWeight = payLoad;
        foreach(Stage stage in stages) {
            currentWeight += stage.getTotalWeight();
        }

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
        alititude = posY;
        velocity = velY;
    }

    void addStage(Stage stage) {
        stages.Add(stage);
    }

    double getGravityAcceleration()
    {
        return -10;
    }

    double getAirResistanceAcceleration(double velocity)
    {

        return (velocity > 0 ? -1 : +1) * 0.001*velocity*velocity; // TODO
    }

    public void updateComponent(Item item)
    {

    }
}
