using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItem : MonoBehaviour
{

    public Item currentItem;
    public TMP_Text description, cost;
    public GameObject textPrefab;
    public List<TMP_Text> textHolders;

    private List<GameObject> createdStats;

    // Start is called before the first frame update
    void Start()
    {
        this.description.enabled = false;
        this.cost.enabled = false;
        this.createdStats = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Item item)
    {
        this.currentItem = item;
    }

    public void ShowDescription()
    {

        this.description.text = this.currentItem.description;
        this.cost.text = "$" + this.currentItem.cost;

        List<string> stats = new List<string>(this.currentItem.stats.Keys);

        for(int i = 0; i < stats.Count; i++)
        {

            TMP_Text statText = this.textHolders[i];
            statText.text = stats[i] + ": " + this.currentItem.stats[stats[i]];
            statText.enabled = true;
            
        }
    }
}
