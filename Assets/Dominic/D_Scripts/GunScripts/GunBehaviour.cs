using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{

    public bool movementReady;
    private void Update()
    {
        if (movementReady == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * 50.0f * Time.fixedUnscaledDeltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward * -50.0f * Time.fixedUnscaledDeltaTime);
            }
        }
    }

    public void ReadyToMove()
    {
        if (movementReady == false)
        {
            movementReady = true;
        }
        else
        {
            movementReady = false;
        }
    }


}
