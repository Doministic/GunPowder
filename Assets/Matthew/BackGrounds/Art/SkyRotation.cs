using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyRotation : MonoBehaviour {

    public float cur_Deg = 0f;
    public float max_Deg = 360f;


    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(eulerAngles: Vector3.forward * Time.deltaTime);
        //cur_Deg = transform.eulerAngles.z;
        //if (Input.GetKeyDown("x"))

    }

    void Degreset(float degrees)
    {
       
    }
}
