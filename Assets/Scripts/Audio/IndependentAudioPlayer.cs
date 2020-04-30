using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentAudioPlayer : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        StartCoroutine(DestroyWhenDone());
    }

    IEnumerator DestroyWhenDone()
    {
        while (audioSource.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
