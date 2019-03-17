using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private Wallet wallet;
    // Start is called before the first frame update
    void Start()
    {
        wallet = FindObjectOfType<Wallet>();
        wallet.setCash(10000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("game");
    }
}
