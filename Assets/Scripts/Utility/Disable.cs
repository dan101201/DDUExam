using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);    
    }

    IEnumerator LateDisable() {
        yield return new WaitForSeconds(5f);
    }
}
