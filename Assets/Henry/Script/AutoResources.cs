using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoResources : MonoBehaviour
{

    // Use this for initialization
    ResourceManager autoResources;
    void Start()
    {
        autoResources = Object.FindObjectOfType<ResourceManager>();
		InvokeRepeating("upResources",1,.5f);
    }

    // Update is called once per frame
    void upResources()
    {
        autoResources.GrainManager(3);
        autoResources.ScrapManager(0);
    }
}
