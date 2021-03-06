﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour
{
    public GameObject projectile;
    float time = 0.0f;
    float ShotTimer = 1.0f;
    public bool ecoMode;
    EcoMode refEcoModeScript;
    MouseLookAtTest refMouseLookAtTest;
    void Start()
    {
        refMouseLookAtTest = GetComponentInParent<MouseLookAtTest>();
        refEcoModeScript = transform.parent.GetChild(2).GetComponent<EcoMode>();
    }
    void Update()
    {
        if (ecoMode == true && refEcoModeScript.ecoModeActive == true)
        {
            SpawnBullet();
        }
        else if (refMouseLookAtTest.moveing == false && ecoMode == false)
        {
            SpawnBullet();
        }
    }
    public void SpawnBullet()
    {
        time += Time.deltaTime;
        if (time >= ShotTimer)
        {
            time = 0;
            transform.localEulerAngles = new Vector3(0, 0, Random.Range(-15, 15));
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 2000.0f);
        }

    }
}

