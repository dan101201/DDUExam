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
        child.transform.Rotate(0.5f, 0.5f, 0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasItem)
        {
            GameObject pickedItem = itemPrefab[Random.Range(0, itemPrefab.Length)];
            Instantiate(pickedItem, other. transform.position, transform.rotation);
            Debug.Log(pickedItem);
            gameObject.GetComponent<Renderer>().material = off;
            hasItem = false;
            PlayAudio();
            Destroy(child);  
        }

    }
    public AudioClip audioSource;
    private AudioSource source;
    public void PlayAudio()
    {
        if (source is null) source = transform.GetComponent<AudioSource>();
        source.clip = audioSource;
        source.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
