using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Transform Block;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clear();
        }
    }
    void clear()
    {
        Instantiate(Block, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
