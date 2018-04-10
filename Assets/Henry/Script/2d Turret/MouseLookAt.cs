using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAt : MonoBehaviour
{
    // Use this for initialization
    public float zAngle;
    MousePosition mosPos;
    GameObject MouseCursor;
    Quaternion desiredRot;
    bool iAmRotating;
    bool canFire;

    [SerializeField]
    Quaternion getParentRotation;
    Transform theParentsTransform;

    void Start()
    {
        MouseCursor = GameObject.Find("MouseCursor");
        mosPos = MouseCursor.GetComponent<MousePosition>();

        canFire = GetComponentInChildren<BulletBehavior>().CanFire();
        canFire = true;

        GetParentsRotation();
        iAmRotating = true;
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

            float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, 90.0f * Time.fixedUnscaledDeltaTime);
            canFire = false;

            zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            desiredRot = Quaternion.Euler(0, 0, zAngle - getParentRotation.eulerAngles.z);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, desiredRot, 90.0f * Time.unscaledDeltaTime);


            if (transform.localRotation == desiredRot)
            {
                zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                desiredRot = Quaternion.Euler(0, 0, zAngle);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, 90.0f * Time.fixedUnscaledDeltaTime);
            }

            if (transform.rotation == desiredRot)
            {
                iAmRotating = false;
                canFire = true;
            }
        }
    }
    public void GetParentsRotation()
    {
        theParentsTransform = GetComponentInParent<Transform>();
        getParentRotation = theParentsTransform.rotation;
    }
}