using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDDj : MonoBehaviour
{
    public AudioClip[] theMusics;

    void Update()
    {
        if (Input.GetKey("1"))
        {
            int clipPick = Random.Range(0, theMusics.Length);
            GetComponent<AudioSource>().clip = theMusics[clipPick];
            GetComponent<AudioSource>().Play();
        }
    }

}
