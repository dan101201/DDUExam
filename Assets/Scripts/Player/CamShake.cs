using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
    bool shaking = false;
	void Update()
	{
		if (shakeDuration > 0)
		{
            if (!shaking) {
                shaking = true;
                originalPos = transform.localPosition;
            }
			transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else  if (shaking)
		{
			shakeDuration = 0f;
			transform.localPosition = originalPos;
            shaking = false;
		}
	}
}
