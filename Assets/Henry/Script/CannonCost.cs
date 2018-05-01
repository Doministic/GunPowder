using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonCost : MonoBehaviour
{
    TotalCost cannonCost;
    Text totalCost;

    // Use this for initialization
    void Start()
    {
        totalCost = GetComponent<Text>();
        cannonCost = FindObjectOfType<TotalCost>();
    }

    // Update is called once per frame
    void Update()
    {
        totalCost.text = "G: " + cannonCost.cannonGrain + " S: " + cannonCost.cannonScrap;
    }
}
