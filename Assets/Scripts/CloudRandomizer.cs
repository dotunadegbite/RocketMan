using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRandomizer : MonoBehaviour
{

    public Sprite cloud1;
    public Sprite cloud2;
    public Sprite cloud3;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
        switch (Mathf.Ceil(Random.Range(0.01f, 3))){
            case 1:
                spriteRenderer.sprite = cloud1;
                break;
            case 2:
                spriteRenderer.sprite = cloud2;
                break;
            case 3:
                spriteRenderer.sprite = cloud3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
