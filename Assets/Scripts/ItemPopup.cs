using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{
    public TMP_Text description;
    public TMP_Text price;
    public Item item;

    public Button equipButton;
    public Button exitButton;

    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.equipButton.onClick.AddListener(EquipItem);
        this.exitButton.onClick.AddListener(DestroySelf);

        this.spawnPoint = GameObject.Find("RocketSpawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem()
    {
        GameObject rocketToSpawn = GameObject.Find("Rocket");
        SpriteRenderer rocketSprite = rocketToSpawn.GetComponent<SpriteRenderer>();
        rocketSprite.enabled = true;
        this.DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
