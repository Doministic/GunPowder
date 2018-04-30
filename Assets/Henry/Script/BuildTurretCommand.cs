using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTurretCommand : MonoBehaviour
{
    public GameObject commandReceiver;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void BuildTurretOfType(string type)
    {
        if (type == "Machine Gun")
        {
            commandReceiver.BroadcastMessage("BuildTurretOfTypeCommand", "Machine Gun");
        }
        if (type == "Shotgun")
        {
            commandReceiver.BroadcastMessage("BuildTurretOfTypeCommand", "Shotgun");
        }
        if (type == "Cannon")
        {
            commandReceiver.BroadcastMessage("BuildTurretOfTypeCommand", "Cannon");
        }
        if (type == "Sniper")
        {
            commandReceiver.BroadcastMessage("BuildTurretOfTypeCommand", "Sniper");
        }
    }
}
