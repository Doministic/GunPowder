using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : BaseSingletonBehaviour<ResourceManager>
{
    private static ResourceManager _instance;
    public int grain;
    public int scrap;
    
    public static ResourceManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ResourceManager>();
            }

            return _instance;
        }
    }

    public void GrainManager(int grainToChange)
    {
        grain += grainToChange;
    }
    public void ScrapManager(int scrapToChange)
    {
        scrap += scrapToChange;
    }
}
