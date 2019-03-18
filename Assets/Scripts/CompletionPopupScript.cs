using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CompletionPopupScript : MonoBehaviour
{

    public TMP_Text completionText;
    UpdateStats updateStats;
    Wallet wallet;
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        wallet = FindObjectOfType<Wallet>();
        popup.SetActive(false);
        updateStats = FindObjectOfType<UpdateStats>();
    }

    public void Update()
    {
        if(updateStats.hasWon)
        {
            completionText.text = "Amazing work, you are rewarded with lots of money";
        }
        else
        {
            completionText.text = "Due to your failure, you will not be compensated for this round";
        }
    }



    public void onContinueClick()
    {
        if(updateStats.hasWon)
        {
            wallet.updateCash(5000); //This is your payment for completing the mission.
        }
        else
        {
            wallet.updateCash(-3000); //This is where you pay for your rocket
        }
        SceneManager.LoadScene("game");
    }

    public void onQuitClick()
    {

    }
}
