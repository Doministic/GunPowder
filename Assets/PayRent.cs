using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayRent : MonoBehaviour
{

    TotalRentCost refTotalRent;
    ResourceManager refResourceManager;
    // Use this for initialization
    void Start()
    {
        refTotalRent = FindObjectOfType<TotalRentCost>();
        refResourceManager = FindObjectOfType<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (refResourceManager.grain >= refTotalRent.totalGrainCost && refResourceManager.grain >= refTotalRent.totalScrapCost)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }
        }
    }
}
