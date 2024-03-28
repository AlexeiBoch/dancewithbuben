using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Sounds: MonoBehaviour
{
    public AudioClip[] sounds;

    public Slider sliderVolumeMusic;
    public AudioSource[] volumeMusic;
    public float voulume1;

    public AudioSource audioScr => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float voulume = 1f, bool destroyed = false)
    {
        if (destroyed)
            AudioSource.PlayClipAtPoint(clip, transform.position, voulume);

        else
            audioScr.PlayOneShot(clip, voulume);
    }

    private void Start()
    {
        SLiderMusic();
    }

    public void SLiderMusic()
    {   
        voulume1 = sliderVolumeMusic.value; 
    }
}
