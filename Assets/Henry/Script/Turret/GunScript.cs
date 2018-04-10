using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool MovementReady;
    GameObject MosLocation;
    void Start()
    {
        MosLocation = GameObject.Find("MouseCursor");
        transform.LookAt(MosLocation.transform);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.Clamp(transform.localEulerAngles.y, 45, 135), transform.localEulerAngles.z);
    }

    void Update()
    {
        if (MovementReady == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("space pressed");
                transform.LookAt(MosLocation.transform);
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.Clamp(transform.localEulerAngles.y, 45, 135), transform.localEulerAngles.z);

            }
        }
    }
    public void printStrings()
    {
        print("something");
    }
    public void readyToMove()
    {
        if (MovementReady == false)
        {
            MovementReady = true;
            print(" I Am ready movement");
        }
        else
        {
            MovementReady = false;
            print(" I Can't Move");
        }
    }
    public void ClearSelection()
    {
        MovementReady = false;
    }
}
