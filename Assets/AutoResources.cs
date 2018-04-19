using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoResources : MonoBehaviour
{

    // Use this for initialization
    ResourceManager auRes;
    void Start()
    {
        auRes = Object.FindObjectOfType<ResourceManager>();
		InvokeRepeating("upResources",1,1);
    }

    // Update is called once per frame
    void upResources()
    {
        auRes.GrainManager(2);
        auRes.ScrapManager(2);
    }
}
