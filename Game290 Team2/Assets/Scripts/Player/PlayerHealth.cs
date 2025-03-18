using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Image healthBar;
    private Vector3 startPosition; 

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if(health <= 0)
        {
             Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition; // Move player back to start
        health = maxHealth; // Restore health
        Debug.Log("Player Respawned!");
    }
}
