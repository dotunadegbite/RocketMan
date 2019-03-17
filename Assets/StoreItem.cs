using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItem : MonoBehaviour
{

    public Item currentItem;
    public TMP_Text description, cost;
    public GameObject textPrefab;
    public List<Transform> statSpawns;

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
        Debug.Log("There are this many things in the list: " + this.createdStats.Count);
        if(this.createdStats.Count > 0)
        {
            
            while(this.createdStats.Count > 0)
            {
                Destroy(this.createdStats[0]);
                Debug.Log(this.createdStats);
                
            }
        }

        this.description.text = this.currentItem.description;
        this.cost.text = "$" + this.currentItem.cost;

        List<string> stats = new List<string>(this.currentItem.stats.Keys);

        for(int i = 0; i < stats.Count; i++)
        {
            GameObject statObject = Instantiate(textPrefab, this.statSpawns[i]);
            TMP_Text statText = textPrefab.GetComponent<TMP_Text>();
            statText.text = stats[i] + ": " + this.currentItem.stats[stats[i]];
            this.createdStats.Add(statObject);
            
        }
        Debug.Log(this.createdStats.Count);
    }
}
