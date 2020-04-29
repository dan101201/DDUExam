using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentAudioPlayer : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
