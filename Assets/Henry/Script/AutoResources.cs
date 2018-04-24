using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoResources : MonoBehaviour
{
    public int grain;
    public int scrap;
    ResourceManager autoResources;
    void Start()
    {
        autoResources = Object.FindObjectOfType<ResourceManager>();
		InvokeRepeating("upResources",1,.5f);
    }

    void upResources()
    {
        autoResources.GrainManager(grain);
        autoResources.ScrapManager(scrap);
    }
}
