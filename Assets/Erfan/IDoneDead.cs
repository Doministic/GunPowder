using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDoneDead : MonoBehaviour
{
    public AudioClip[] clips;
    // Use this for initialization
    void OnDestroy()
    {
        int clipPick = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().clip = clips[clipPick];
        GetComponent<AudioSource>().Play();
    }
}
