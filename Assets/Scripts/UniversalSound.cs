using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayAudio(AudioClip audio) {
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void PlayAudio() {
        audioSource.Play();
    }
}
