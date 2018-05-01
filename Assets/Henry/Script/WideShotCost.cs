using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WideShotCost : MonoBehaviour
{
    TotalCost wideShotCost;
    Text totalCost;

    // Use this for initialization
    void Start()
    {
        totalCost = GetComponent<Text>();
        wideShotCost = FindObjectOfType<TotalCost>();
    }

    // Update is called once per frame
    void Update()
    {
        totalCost.text = "G: " + wideShotCost.wideShotGrain + " S: " + wideShotCost.wideShotScrap;
    }
}
