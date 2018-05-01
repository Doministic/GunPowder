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

    public GameObject buildLocation;
    // Use this for initialization
    void Start()
    {
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
            if (turretType == "Machine Gun")
            {
                print("Building Machine Gun");
                Instantiate(machineGun, buildLocation.transform.position, Quaternion.identity);
            }
            if (turretType == "Shotgun")
            {
                print("Building Shotgun");
                Instantiate(shotgun, buildLocation.transform.position, Quaternion.identity);
            }
            if (turretType == "Cannon")
            {
                print("Building Cannon");
                Instantiate(cannon, buildLocation.transform.position, Quaternion.identity);
            }
            if (turretType == "Sniper")
            {
                print("Building Sniper");
                Instantiate(sniper, buildLocation.transform.position, Quaternion.identity);
            }
            tileList.BroadcastMessage("TileIsClosed");
        }
    }
}
