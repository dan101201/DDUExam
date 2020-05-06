using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Material off;
    bool hasItem = true;
    GameObject child;
    DungeonGenerationScript generation;
    private void Start()
    {
        generation = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DungeonGenerationScript>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject tempChild = gameObject.transform.GetChild(i).gameObject;
            if (tempChild.name == "Item")
            {
                child = tempChild;
            }
        }
    }
    bool once = false;
    
    private void FixedUpdate()
    {
        if (!once && generation.DoneGenerating) {
            Instantiate(itemPrefab[Random.Range(0,itemPrefab.Length)]);
            once = true;
        }
        if (child != null)
        {
            child.transform.Rotate(0.5f, 0.5f, 0.5f);
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
