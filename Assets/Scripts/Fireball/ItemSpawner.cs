using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Material off;
    bool hasItem = true;
    GameObject child;
    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject tempChild = gameObject.transform.GetChild(i).gameObject;
            if (tempChild.name == "Item")
            {
                child = tempChild;
            }
        }
    }
    private void FixedUpdate()
    {
        if (child != null)
        {
            child.transform.Rotate(0.5f, 0.5f, 0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasItem)
        {
            hasItem = false;
            GameObject pickedItem = itemPrefab[Random.Range(0, itemPrefab.Length)];
            Instantiate(pickedItem, other. transform.position, transform.rotation);
            Debug.Log(pickedItem);
            gameObject.GetComponent<Renderer>().material = off;
            PlayAudio();
            Destroy(child);  
        }

    }
    public AudioClip audioClip;
    private AudioSource source;
    public void PlayAudio()
    {
        if (source is null) source = transform.GetComponent<AudioSource>();
        if (source is null) return;
        source.clip = audioClip;
        source.Play();
    }
}
