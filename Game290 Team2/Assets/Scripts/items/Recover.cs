using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    public float oxygenAmount = 0f; // Amount of oxygen to recover
    public float HealthAmount = 0f; // Maximum oxygen capacity
    void Awake()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.RefillOxygen(oxygenAmount);
            playerHealth.RefillHealth(HealthAmount);
            Destroy(gameObject);
        }
    }
}
