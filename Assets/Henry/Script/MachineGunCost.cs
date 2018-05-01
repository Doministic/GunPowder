using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MachineGunCost : MonoBehaviour
{
    TotalCost machineGunCost;
    Text totalCost;

    // Use this for initialization
    void Start()
    {
        totalCost = GetComponent<Text>();
        machineGunCost = FindObjectOfType<TotalCost>();
    }

    // Update is called once per frame
    void Update()
    {
        totalCost.text = "G: " + machineGunCost.machineGunGrain + " S: " + machineGunCost.machineGunScrap;
    }
}
