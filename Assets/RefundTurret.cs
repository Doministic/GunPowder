﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefundTurret : MonoBehaviour
{
Turret refRefundCommand;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RefundSelectedTurrets()
    {
        refRefundCommand = FindObjectOfType<Turret>();
		refRefundCommand.SendMessage("RefundTurret");
    }
}
