using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private PlayerHealth phealth;
    public float damage = 20f;
    public bool usingCollider = false;
    GameObject player;
    public float damageRadius = 1f;
    float timeOutOfSight = 0f;
    enemyDetector enemyDetector;

    AudioManager audioManager;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        phealth = player.GetComponent<PlayerHealth>();
        if (player == null && phealth == null)
        {
            Debug.LogError("Player or PlayerHealth component not found on player object.");
            return;
        }
        enemyDetector = GetComponentInParent<enemyDetector>();
        if (usingCollider)
        {
            Collider2D collider = GetComponent<Collider2D>();
        }

        audioManager = FindObjectOfType<AudioManager>();
    }

    float distance()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance;
    }

    void Update()
    {
        if (distance() < damageRadius)
        {
            if (phealth != null)
            {
                phealth.takeDamge(damage * Time.deltaTime);// Apply damage over time
                //Debug.Log("Player health: " + phealth.health);
                audioManager.PlayDamageSound();
                if (enemyDetector != null)
                {
                    enemyDetector.timeOutOfSight = 0f; // Reset the timer when the player is in sight
                }
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on player object.");
                return;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && usingCollider)
        {
            if (phealth != null)
            {
                phealth.takeDamge(damage * Time.deltaTime);// Apply damage over time
                audioManager.PlayDamageSound();
                //Debug.Log("Player health: " + phealth.health);
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on player object.");
                return;
            }
        }
    }
}
