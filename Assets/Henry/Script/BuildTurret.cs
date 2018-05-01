using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTurret : MonoBehaviour
{
    public GameObject machineGun;
    public GameObject shotgun;
    public GameObject cannon;
    public GameObject sniper;

    public GameObject tileList;

    TileSelected selectionRef;
    TileTaken tileTakenRef;
    ResourceManager refResourceManager;
    TotalCost refTotalCost;

    public GameObject buildLocation;
    // Use this for initialization
    void Start()
    {
        refResourceManager = FindObjectOfType<ResourceManager>();
        refTotalCost = FindObjectOfType<TotalCost>();
        selectionRef = this.GetComponent<TileSelected>();
        tileTakenRef = this.GetComponent<TileTaken>();
        tileList = GameObject.Find("Tile List");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BuildTurretOfTypeCommand(string turretType)
    {
        if (selectionRef.tileSelected && tileTakenRef.tileOpen)
        {
            if ((turretType == "Machine Gun") && (refResourceManager.grain > 35) && (refResourceManager.scrap > 45))
            {
                print("Building Machine Gun");
                Instantiate(machineGun, buildLocation.transform.position, Quaternion.identity);
                refTotalCost.updateMachineGunCost(35, 45);

            }
            if ((turretType == "Shotgun") && (refResourceManager.grain > 60) && (refResourceManager.scrap > 20))
            {
                print("Building Shotgun");
                Instantiate(shotgun, buildLocation.transform.position, Quaternion.identity);
                refTotalCost.updateWideShotCost(60, 20);

            }
            if ((turretType == "Cannon") && (refResourceManager.grain > 25) && (refResourceManager.scrap > 30))
            {
                print("Building Cannon");
                Instantiate(cannon, buildLocation.transform.position, Quaternion.identity);
                refTotalCost.updateCannonCost(25, 30);
            }
            if ((turretType == "Sniper") && (refResourceManager.grain > 50) && (refResourceManager.scrap > 50))
            {
                print("Building Sniper");
                Instantiate(sniper, buildLocation.transform.position, Quaternion.identity);
                refTotalCost.updateSniperCost(50, 50);
            }
            tileList.BroadcastMessage("TileIsClosed");
        }
    }
}
