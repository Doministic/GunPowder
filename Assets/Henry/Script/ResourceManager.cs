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
                _instance = GameObject.FindObjectOfType<ResourceManager>();

                //Tell unity not to destroy this object when loading a new scene!
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
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
