using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillYoSelf : MonoBehaviour
{
    void Update()
    {
            Destroy(gameObject, .5f);
    }
}
