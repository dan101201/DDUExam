using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float smoothing = 5f;

    Transform target;
    Vector3 offset;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(target);
        offset = transform.position - target.position;
    }

    void Update()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

