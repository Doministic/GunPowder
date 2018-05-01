using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSelected : MonoBehaviour
{
    public GameObject tileList;
    public static GameObject thisTile;
    public bool tileSelected;
    public Material yesBuildMat;
    public Material noBuildMat;

    void Update()
    {

    }
    void OnMouseDown()
    {
        tileSelected = !tileSelected;

        if (tileSelected == true)
        {
            SelectTile();
            thisTile = this.gameObject;
            tileList.BroadcastMessage("DeselectTile");
        }
        else
        {
            thisTile = null;
            DeselectTile();
        }
    }
    public void DeselectTile()
    {
        if (thisTile != this.gameObject)
        {
            tileSelected = false;
            GetComponent<Renderer>().material = noBuildMat;
        }
    }
    public void SelectTile()
    {
        tileSelected = true;
        GetComponent<Renderer>().material = yesBuildMat;
    }
}
