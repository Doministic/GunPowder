using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMTest : BaseSingletonBehaviour<RMTest>
{
    ResourceManager resMan;
    // Use this for initialization
    // Update is called once per frame
    void Start()
    {
        resMan = GameObject.FindObjectOfType<ResourceManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            resMan.GrainManager(4);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            resMan.ScrapManager(3);
        }
    }
}
