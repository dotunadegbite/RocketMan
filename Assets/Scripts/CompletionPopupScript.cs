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
    }



    public void onContinueClick()
    {
        SceneManager.LoadScene("game");
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
}
