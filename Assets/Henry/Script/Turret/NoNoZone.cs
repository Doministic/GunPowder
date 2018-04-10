using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoNoZone : MonoBehaviour
{
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        print("Something WENT IN ME!!!!");
    }
    void OnTriggerExit(Collider other)
    {
        print("Something went boop");
    }
}






