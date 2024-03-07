using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerSettings: MonoBehaviour
{
    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;
    [SerializeField] GameObject buttonAudio;

    [SerializeField] Slider slider;

    
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip clip;

    private void Update()
    {
        audioSource.volume = slider.value;
    }

    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
