using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelected : MonoBehaviour
{
    public bool selectionStatus;

    void Update()
    {

    }
    void OnMouseDown()
    {
        selectionStatus = !selectionStatus;
    }
}
