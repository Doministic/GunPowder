using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRaycast : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, Vector3.forward, out hitinfo, 1))
		{
			print (hitinfo.collider.name);
		}
            Debug.DrawRay(transform.position, Vector3.forward * 1, Color.blue, 10);
    }
}
