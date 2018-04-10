using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickTest : MonoBehaviour
{
    public GameObject[] testSceneObjects;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonClickTestUI(string gunModeToSwitchTo)
    {
        testSceneObjects = GameObject.FindGameObjectsWithTag("test");

        foreach (GameObject test in testSceneObjects)
        {
            test.GetComponent<ReceiveButtonMessage>().GunButtonClick(gunModeToSwitchTo);
        }
    }
}
