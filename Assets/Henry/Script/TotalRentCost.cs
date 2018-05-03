using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalRentCost : MonoBehaviour
{
    ResourceManager resourceManager;
    TotalCost totalRentCost;
    public int totalGrainCost;
    public int totalScrapCost;
    Text totalCost;

    // Use this for initialization
    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        totalCost = GetComponent<Text>();
        totalRentCost = FindObjectOfType<TotalCost>();
    }

    // Update is called once per frame
    void Update()
    {
        addGrains();
        addScraps();
        totalCost.text = "G: " + totalGrainCost + " S: " + totalScrapCost;
    }
    public void addGrains()
    {
        totalGrainCost = totalRentCost.machineGunGrain + totalRentCost.wideShotGrain + totalRentCost.cannonGrain + totalRentCost.sniperGrain;
    }
    public void addScraps()
    {
        totalScrapCost = totalRentCost.machineGunScrap + totalRentCost.wideShotScrap + totalRentCost.cannonScrap + totalRentCost.sniperScrap;
    }
    public void UpdateResources(){
        resourceManager.GrainManager(-totalGrainCost);
        resourceManager.ScrapManager(-totalScrapCost);
    }
}
