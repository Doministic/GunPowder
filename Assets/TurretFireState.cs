﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class TurretFireState : MonoBehaviour
{
    Animator TurretState;
    // Use this for initialization
    void Start()
    {
        TurretState = gameObject.GetComponent<Animator>();
        // TurretState.SetBool("CannonIdle", false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
