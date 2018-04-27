using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip[] clips;
    public void IGotHitSound()
    {
        int clipPick = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().clip = clips[clipPick];
        GetComponent<AudioSource>().Play();
    }
}
