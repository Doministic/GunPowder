using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperCost : MonoBehaviour
{
    TotalCost sniperCost;
    Text totalCost;

    // Use this for initialization
    void Start()
    {
        totalCost = GetComponent<Text>();
        sniperCost = FindObjectOfType<TotalCost>();
    }

    // Update is called once per frame
    void Update()
    {
        totalCost.text = "Grain: " + sniperCost.sniperGrain + " Scrap: " + sniperCost.sniperScrap;
    }
}
