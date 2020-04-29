using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentAudioPlayer : MonoBehaviour
{
    public static GameObject independentAudioObject;

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
        if (audioSource.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
