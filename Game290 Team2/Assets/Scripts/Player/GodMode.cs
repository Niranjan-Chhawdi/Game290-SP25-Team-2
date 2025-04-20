using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    PlayerHealth playerHealth;
    GameObject indicator;
    bool isGodModeActive = false;
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        indicator = GameObject.Find("GodModeIndicator");
    }
    void Update()
    {
        if (isGodModeActive)
        {
            playerHealth.health = playerHealth.maxHealth;
            playerHealth.currentOxygen = playerHealth.maxOxygen;
            indicator.SetActive(true);
        }
        else
        {
            indicator.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            isGodModeActive = !isGodModeActive;
            if (isGodModeActive)
            {
                Debug.Log("God Mode Activated");
            }
            else
            {
                Debug.Log("God Mode Deactivated");
            }
        }
    }
}
