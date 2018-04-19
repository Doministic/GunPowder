using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapScript : MonoBehaviour
{

    ResourceManager scrapCount;
    Text scrap;
    // Use this for initialization

    void Start()
    {
        scrap = GetComponent<Text>();
		scrapCount = Object.FindObjectOfType<ResourceManager>();
    }
    // Update is called once per frame
    void Update()
    {
        scrap.text = "SCRAP: " + scrapCount.scrap;
    }
}
