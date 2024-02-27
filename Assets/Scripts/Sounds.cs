using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds: MonoBehaviour
{
    public AudioClip[] sounds;
    
    public AudioSource audioScr => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float voulume = 1f, bool destroyed = false)
    {
        if (destroyed)
            AudioSource.PlayClipAtPoint(clip, transform.position, voulume);            
        else
            audioScr.PlayOneShot(clip, voulume);
    }
}
