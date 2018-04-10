using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovementBehaviour : MonoBehaviour {

	
    MousePosition mosPos;
    GameObject MouseCursor;
    Quaternion desiredRot;
    bool iAmRotating;

    void Start()
    {
        MouseCursor = GameObject.Find("MouseCursor");
        mosPos = MouseCursor.GetComponent<MousePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            iAmRotating = true;
        }
        if (iAmRotating == true)
        {
            Vector3 direction = MouseCursor.transform.position - transform.position;
            direction.Normalize();
            float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.AngleAxis(zAngle, Vector2.up);
            if (transform.rotation == desiredRot)
            {
                iAmRotating = false;
            }
        }
    }
}
