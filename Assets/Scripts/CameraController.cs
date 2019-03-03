using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject rocket;
    public float smoothTime = 1F;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        Debug.Log("camera online");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, rocket.transform.position.y, transform.position.z);
        Vector3 smoothedTransform = Vector3.SmoothDamp(
            transform.position,
            rocket.transform.position - new Vector3(0, 0, 10), ref velocity, smoothTime);
        transform.position = new Vector3(smoothedTransform.x, rocket.transform.position.y, transform.position.z);
        Debug.Log(transform.position);
    }
}