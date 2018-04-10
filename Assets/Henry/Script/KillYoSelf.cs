using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillYoSelf : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(1000, 1000, 1000);
            Destroy(gameObject, 2);
        }
    }
}
