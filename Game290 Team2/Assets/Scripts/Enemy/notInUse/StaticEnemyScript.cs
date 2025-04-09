using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyScript : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn(other.gameObject);
        }
    }

    void Respawn(GameObject player)
    {
        if (respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;
            Debug.Log("Player Respawned!");
        }
        else
        {
            Debug.LogError("Respawn Point not set!");
        }
    }
}
