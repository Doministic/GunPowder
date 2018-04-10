using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject spawner;

    [SerializeField]
    private int num = 0;


    // Use this for initialization
    void Start()
    {
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 1)
        {
            spawner.SetActive(true);
        }
        else
        {
            spawner.SetActive(false);
        }
    }
    private void OnMouseEnter()
    {
        num = 1;
    }
    private void OnMouseExit()
    {
        num = 0;
    }
}
