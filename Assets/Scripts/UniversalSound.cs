using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float fade;

    public void PlayAudio(AudioClip audio) {
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void PlayAudio() {
        audioSource.Play();
    }

    public void FadePlayAudio(AudioClip audio) {
        var audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = audio;
        audioSource2.volume = 0;
        audioSource2.Play();
        audioSource2.clip = audio;
        StartCoroutine("FadeAudio",audioSource2);
    }

    IEnumerator FadeAudio(AudioSource source) {
        float tempVolume = audioSource.volume;
        while (source.volume < tempVolume)
        {
            source.volume += fade/100;
            audioSource.volume -= fade/100;
            yield return new WaitForSeconds(0.05f);
        }
        source.volume = tempVolume;
        yield return null;
    }
}
