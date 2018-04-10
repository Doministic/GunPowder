using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCheck : MonoBehaviour
{
    [SerializeField]
    bool canBeClickedOn, isTileTaken, homeBaseIsNear;
    public Material yesBuildMat;
    public Material noBuildMat;
    public GameObject basicBuilding;
    public Transform basicBuildingLocation;
    // Use this for initialization
    void Start()
    {
        CheckIfBaseIsNearBy();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseEnter()
    {
        canBeClickedOn = true;
        CheckIfBaseIsNearBy();
    }
    void OnMouseExit()
    {
        canBeClickedOn = false;
    }
    void OnMouseDown()
    {
        if (canBeClickedOn == true)
        {
            CheckIfIsTileTaken();
            CheckIfBaseIsNearBy();
            if (isTileTaken == false && homeBaseIsNear == true)
            {
                Instantiate(basicBuilding, basicBuildingLocation);
                print("I Spawned Something");
                GetComponent<Renderer>().material = noBuildMat;
            }
        }
    }
    void CheckIfIsTileTaken()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward * -1, out hitInfo, 2))
        {
            print("I cant spawn here " + hitInfo.collider.gameObject.name + " is in the way ");
            isTileTaken = true;
        }
        else if (!Physics.Raycast(transform.position, transform.forward * -1, out hitInfo, 2))
        {
            print("Nothing Was There or HomeBase is not near");
            isTileTaken = false;
            CheckIfBaseIsNearBy();
        }
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), Color.green, 5);
    }
    void CheckIfBaseIsNearBy()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position, .75f, transform.forward * -1, out hitInfo))
        {
            if (hitInfo.collider.tag == "HomeBase")
            {
                print("I am near HomeBase");
                homeBaseIsNear = true;
                GetComponent<Renderer>().material = yesBuildMat;
            }
        }
        else if (!Physics.SphereCast(transform.position, .75f, transform.forward * -1, out hitInfo))
        {
            print("HomeBase is not near");
            homeBaseIsNear = false;
            GetComponent<Renderer>().material = noBuildMat;
        }
    }
}
