using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject rocket;
    public float smoothTime = 1F;
    private Vector3 velocity = Vector3.zero;
    public GameObject cloudObject;

    private float startTime;
    public float GameDuration;
    private Color backgroundcolor;
    private float H, S, V, originalV;
    private const float maxHeight = 3000,
                    minCloudHeight = maxHeight / 13,
                    maxCloudHeight = maxHeight / 2,
                    minStarHeight = maxHeight / 3 * 1.3f;
    private bool starsGenerated;

    private List<GameObject> clouds;

    public Camera cam;

    void Start()
    {
        clouds = new List<GameObject>();
        H = 0.5527777778f;
        S = 0.69f;
        originalV = 0.96f;
        //V = originalV;
        backgroundcolor = Color.HSVToRGB(H, S, V);
        startTime = Time.time;
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        starsGenerated = false;
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
        changeBackgroundColor();

        float y = transform.position.y;
        if(minCloudHeight < y && y < maxCloudHeight)
        {
            generateClouds();
        }
        else if(y > minStarHeight)
        {
            generateStars();
        }
    }

    void changeBackgroundColor()
    {
        V = (1 - transform.position.y / maxHeight) * originalV;
        backgroundcolor = Color.HSVToRGB(H, S, V);
        cam.backgroundColor = backgroundcolor;
    }

    void generateClouds()
    {
        GameObject newCloud = Instantiate(cloudObject);
        newCloud.transform.position = new Vector3(
            transform.position.x + Random.RandomRange(0, 120) - 60,
            transform.position.y * 1.05f + Random.Range(20, 30),
            Random.RandomRange(40, 80));

        newCloud.transform.localScale = new Vector3(Random.Range(3, 9), Random.RandomRange(3, 9), 1);
        clouds.Add(newCloud);

        List<GameObject> newClouds = new List<GameObject>();
        foreach(GameObject cloud in clouds)
        {
            if (transform.position.y - cloud.transform.position.y > 40)
            {
                Destroy(cloud);
            }
            else
            {
                newClouds.Add(cloud);
            }
        }
        clouds = newClouds;
    }

    void generateStars()
    {
        if (starsGenerated)
        {
            return;
        }
        else {
            starsGenerated = true;
        }
        for(int starNum = 0; starNum < 300; starNum++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(
                Random.Range(-1000, 1000),
                Random.Range(minStarHeight / 2, maxHeight),
                Random.Range(800, 1000));
            sphere.transform.localScale = new Vector3(3, 3, 3);
        }
    }
}