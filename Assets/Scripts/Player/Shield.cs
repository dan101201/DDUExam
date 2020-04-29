using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float maxStamina = 100;
    public float stamina = 100;
    public float staminaConsumption = 1;
    public float staminaRegeneration = 1;
    public float cooldown = 1;
    private float timer;
    public GameObject shield;
    public bool shielding = false;
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (shielding) {
            stamina -= staminaConsumption;
            if (stamina <= 0) {
                shielding = false;
                shield.SetActive(false);
                stamina = Mathf.Max(stamina,0);
            }
        } 
        else 
        {
            stamina += staminaRegeneration;
            stamina = Mathf.Min(stamina,100);
        }
        if (Input.GetMouseButtonDown(1) && timer >= cooldown) {
            shielding = true;
            shield.SetActive(true);
            timer = 0;
        }
        else if (Input.GetMouseButtonUp(1)) 
        {
            shielding = false;
            shield.SetActive(false);
        }
    }
}
