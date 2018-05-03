using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillYoSelf : MonoBehaviour
{
    void Update()
    {
            Destroy(gameObject, .5f);
    }private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
    }


}
