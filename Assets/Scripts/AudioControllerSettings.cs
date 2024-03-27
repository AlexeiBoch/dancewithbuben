using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerSettings: MonoBehaviour
{
    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;
    //[SerializeField] GameObject buttonAudio;

    [SerializeField] Slider[] sliders;
    [SerializeField] AudioClip[] clips;


    // [SerializeField] AudioSource audioSource;

    // [SerializeField] AudioClip clip;

    private void Awake()
    {
        // Воспроизводим все звуки при старте игры
        for (int i = 0; i < clips.Length; i++)
        {
            AudioSource.PlayClipAtPoint(clips[i], transform.position);
        }
    }

    private void Update()
    {
        // Устанавливаем громкость для каждого звука от соответствующего слайдера
        for (int i = 0; i < sliders.Length; i++)
        {
            AudioListener.volume = sliders[i].value;
        }
    }

    public void OnOffAudio(int index)
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            // Установите изображение кнопки audioOff для index-го звука
        }
        else
        {
            AudioListener.volume = 1;
            // Установите изображение кнопки audioOn для index-го звука
        }
    }
}
