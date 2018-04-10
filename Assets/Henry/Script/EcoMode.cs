using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoMode : MonoBehaviour
{
    public int enemies;
    public bool ecoModeActive;
    // Use this for initialization
    void Update()
    {
        if (enemies > 0)
        {
            ecoModeActive = true;
        }
        else
        {
            ecoModeActive = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ++enemies;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            --enemies;
        }
    }
}
