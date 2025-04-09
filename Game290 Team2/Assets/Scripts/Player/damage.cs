using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private PlayerHealth phealth;
    public float damage = 20f;
    GameObject player;
    public float damageRadius = 1f;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        phealth = player.GetComponent<PlayerHealth>();
        if (player == null && phealth == null)
        {
            Debug.LogError("Player or PlayerHealth component not found on player object.");
            return;
        }
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
                phealth.health -= damage * Time.deltaTime; // Apply damage over time
                Debug.Log("Player health: " + phealth.health);
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on player object.");
                return;
            }
        }
    }
}
