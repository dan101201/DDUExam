using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float smoothing = 5f;
    public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

    public GameObject target;
    Vector3 offset;

    Vector3 originalPosition;
    bool shaking = false;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform);
        offset = transform.position - target.transform.position;
    }

    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.transform.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 0.1f);
    }
}

