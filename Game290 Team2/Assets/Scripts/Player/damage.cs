using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public PlayerHealth phealth;
    public float damage = 10f;
    private void OnCollisionEnter2D(Collision2D other)

    {
        if(other.gameObject.CompareTag("Player"))
        {
            phealth.health -= damage;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Smoke hit the player!");
            
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.health -= damage;
            }
        }
    }
}
