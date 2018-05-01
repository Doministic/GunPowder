using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoResources : MonoBehaviour
{
    public int grain = 1;
    public int scrap = 1;
    ResourceManager autoResources;
    void Start()
    {
        autoResources = Object.FindObjectOfType<ResourceManager>();
        StartCoroutine("UpResources");
    }

    IEnumerator UpResources()
    {
        while (true)
        {
            autoResources.GrainManager(grain);
            autoResources.ScrapManager(scrap);
            yield return new WaitForSeconds(1);
        }
    }
}
