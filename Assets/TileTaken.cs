using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileTaken : MonoBehaviour
{
    public bool tileOpen;
    TileSelected selectionRef;
    public GameObject tileList;


    void Start()
    {
        tileOpen = true;
        selectionRef = this.GetComponent<TileSelected>();
        tileList = GameObject.Find("Tile List");
    }
    // Use this for initialization
    public void TileIsOpen()
    {
        tileOpen = true;
    }
    public void TileIsClosed()
    {
        if (selectionRef.tileSelected)
        {
            tileOpen = false;
            tileList.BroadcastMessage("DeselectAfterBuild");
        }
    }
}
