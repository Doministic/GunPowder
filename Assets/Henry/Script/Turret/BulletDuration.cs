using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDuration : MonoBehaviour
{
    public Transform bulletPrefab;
    public void Start()
    {
        Destroy(gameObject, 2);
    }
}
