using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRandomSound : MonoBehaviour
{
    public AudioClip[] clips;

    // Use this for initialization
    void Start()
    {
        int clipPick = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().clip = clips[clipPick];
        GetComponent<AudioSource>().Play();
    }
}
