using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrainScript : MonoBehaviour
{
    ResourceManager grainCount;
    Text grain;
    // Use this for initialization

    // Update is called once per frame
    void Start()
    {
        grain = GetComponent<Text>();
        grainCount = Object.FindObjectOfType<ResourceManager>();
    }
    void Update()
    {
        grain.text = "GRAIN: " + grainCount.grain;
    }
}
