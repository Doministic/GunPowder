using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSelection : MonoBehaviour
{
    void OnMouseDown()
    {
        BroadcastMessage("ClearSelection");
    }
}
