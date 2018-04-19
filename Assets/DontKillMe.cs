using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontKillMe : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
