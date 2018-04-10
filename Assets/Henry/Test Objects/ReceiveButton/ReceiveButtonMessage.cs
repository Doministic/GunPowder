using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveButtonMessage : MonoBehaviour
{
    public enum GunModes
    {
        Eco, Auto, Hold
    }
    public bool selected;
    public GunModes currentMode;
    // Use this for initialization
    void Start()
    {
        selected = false;
        print(currentMode);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        selected = !selected;
        print(selected);
    }
    public void GunButtonClick(string gunModeToSwitchTo)
    {
        if (selected == true)
        {
            if (gunModeToSwitchTo == "Eco")
            {
                currentMode = GunModes.Eco;
                print("I am ECO Now!");
            }
            if (gunModeToSwitchTo == "Auto")
            {
                currentMode = GunModes.Auto;
                print("I am AUTO Now!");
            }
            if (gunModeToSwitchTo == "Hold")
            {
                currentMode = GunModes.Hold;
                print("I am HOLDING Now!");
            }
        }
    }
}


