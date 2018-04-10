using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAtTest : MonoBehaviour
{
    bool iCanMove;
    public bool moveing;
    public Transform crossHair;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            iCanMove = GetComponentInParent<Turret>().turretSelected;
            print(iCanMove);
        }
        if (iCanMove == true)
        {
            Vector3 direction = crossHair.transform.position - transform.position;
            float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, 90.0f * Time.fixedUnscaledDeltaTime);
            moveing = true;

            if (transform.rotation == desiredRot)
            {
                moveing = !moveing;
            }
        }
    }
}
