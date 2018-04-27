using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnimationBehavior : MonoBehaviour {

    Animator can;

    void Start()
    {
        can = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) can.SetTrigger("CannonFire");
        if (Input.GetKeyUp(KeyCode.Space)) can.SetTrigger("CannonIdle");
    }
}
