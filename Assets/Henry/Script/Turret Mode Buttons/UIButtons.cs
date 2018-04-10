using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject[] Selections;
    GunScript SelectedTurrets;


    public bool Eco;
    public bool Auto;
    public bool Hold;

    void Start()
    {
        Selections = GameObject.FindGameObjectsWithTag("turret");
        SelectedTurrets = GetComponent<GunScript>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonUiClick()
    {
        if (Eco == true)
        {
            print(" Eco");
            foreach (GameObject turret in Selections)
            {
                print("hello");
            }
            SelectedTurrets.printStrings();

        }
        if (Auto == true)
        {
            print(" Auto ");
        }
        if (Hold == true)
        {
            print(" Hold ");
        }
    }
}
