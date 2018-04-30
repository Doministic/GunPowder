using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurret : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BuildTurretOfTypeCommand(string turretType)
    {
        if (turretType == "Machine Gun")
        {
            print("buildig Machine Gun");

        }
        if (turretType == "Shotgun")
        {
            print("buildig Shotgun");

        }
        if (turretType == "Cannon")
        {
            print("buildig Cannon");

        }
        if (turretType == "Sniper")
        {
            print("buildig Sniper");

        }
    }
}
