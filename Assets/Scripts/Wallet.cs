using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField]
    private int cash;
    [SerializeField]
    private static bool created = false;

    private int round;

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

    public int getRound()
    {
        return this.round;
    }

    public void incrementRound()
    {
        this.round++;
    }

    private void Awake()
    {
        Debug.Log("This round: " + round);
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            this.setCash(10000);
            round = 0; //Iterated on immediately, making rounds 1 indexed
        }
        else
        {
            Debug.Log("Destroy mamager");
            Destroy(this);

        }
    }
}
