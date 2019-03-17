using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wallet : MonoBehaviour
{
    private int cash;

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

        DontDestroyOnLoad(this.gameObject);
    }
}
