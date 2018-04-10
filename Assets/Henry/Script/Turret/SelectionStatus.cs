using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionStatus : MonoBehaviour
{
    Turret myParent;
    // Use this  for initialization

    public void OnMouseDown()
    {
        GetComponentInParent<Turret>().TurretSelection();
        GetComponentInChildren<cakeslice.Outline>().OutlineSwitch();
    }
}
