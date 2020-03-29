using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Material off;
    bool hasItem = true;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasItem)
        {
            GameObject pickedItem = itemPrefab[Random.Range(0, itemPrefab.Length)];
            Instantiate(pickedItem, other. transform.position, transform.rotation);
            Debug.Log(pickedItem);
            gameObject.GetComponent<Renderer>().material = off;
            hasItem = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
