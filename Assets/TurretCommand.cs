using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretCommand : MonoBehaviour
{
    public Turret[] refTurrets;
    // Use this for initialization
    void Start()
    {
        refTurrets = FindObjectsOfType<Turret>();
    }

    // Update is called once per frame
    public void SendTurretCommand(string command)
    {
        if (command == "eco")
        {
            print("test");
            foreach (Turret refTurret in refTurrets)
            {
                if (refTurret.turretSelected)
                {
                    BroadcastMessage("FlipEcoMode");
                }
            }
        }
        if (command == "hold")
        {
            print("test");
            foreach (Turret refTurret in refTurrets)
            {
                if (refTurret.turretSelected)
                {
                    BroadcastMessage("FlipEcoMode");
                }
            }
        }
    }
}
