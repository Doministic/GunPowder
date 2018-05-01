using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCost : MonoBehaviour
{
    public int machineGunGrain;
    public int machineGunScrap;

    public int wideShotGrain;
    public int wideShotScrap;

    public int cannonGrain;
    public int cannonScrap;

    public int sniperGrain;
    public int sniperScrap;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateMachineGunCost(int grain, int scrap)
    {
        machineGunGrain += grain;
        machineGunScrap += scrap;
    }
    public void updateWideShotCost(int grain, int scrap)
    {
        wideShotGrain += grain;
        wideShotScrap += scrap;
    }
    public void updateCannonCost(int grain, int scrap)
    {
        cannonGrain += grain;
        cannonScrap += scrap;
    }
    public void updateSniperCost(int grain, int scrap)
    {
        sniperGrain += grain;
        sniperScrap += scrap;
    }
}

