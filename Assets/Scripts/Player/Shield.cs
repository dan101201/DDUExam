using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float maxStamina = 100;
    public float stamina = 100;
    public float staminaConsumption = 1;
    public float staminaRegeneration = 1;
    public GameObject shield;
    bool shielding = false;
    void FixedUpdate()
    {
        if (shielding) {
            stamina -= staminaConsumption;
        } 
        else 
        {
            stamina += staminaRegeneration;
        }
        if (Input.GetMouseButtonDown(1)) {
            shielding = true;
            shield.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(1)) 
        {
            shielding = false;
            shield.SetActive(false);
        }
    }
}
