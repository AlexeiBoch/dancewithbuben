using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichSound : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip musicZone1;
    public AudioClip musicZone2;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Zone1"))
        {
            PlayMusic(musicZone1);
        }

        else if (coll.CompareTag("Zone2"))
        {
            PlayMusic(musicZone2);
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        if(clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
