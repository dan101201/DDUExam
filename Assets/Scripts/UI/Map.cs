using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 oldHit;
    private Vector3 initialOffset;
    private bool dragging;
    public float speed;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragging = true;
                initialOffset = hit.point - hit.transform.position;
            } 
            else if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
            }
            else if (dragging)
            {
                hit.transform.position = hit.point - initialOffset;
            }
        }
        
    }
}
