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
        //this.GetComponent<>
    }

    public void onClickLaunch() 
    {

        rocket.startRocket();
        this.gameObject.SetActive(false);

    }


}
