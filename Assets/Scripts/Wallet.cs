using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField]
    private int cash;
    [SerializeField]
    private static bool created = false;

    public void setCash(int cash)
    {
        this.cash = cash;
    }

    public void updateCash(int amount)
    {
        this.cash += amount;
    }

    public int getCash()
    {
        return cash;
    }

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            this.setCash(10000);
        }
        else
        {
            Debug.Log("Destroy mamager");
            Destroy(this);
        }
    }
}
