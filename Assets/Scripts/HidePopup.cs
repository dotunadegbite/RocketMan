using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePopup : MonoBehaviour
{

    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(true);
    }

    public void HideThisObject()
    {
        popup.SetActive(false);
    }


}
