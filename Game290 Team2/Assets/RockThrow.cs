using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
    public float throwForce = 10f;
    public AudioSource throwSound;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ThrowRock(Vector2 direction)
    {
        if (rb != null)
        {
            rb.velocity = direction * throwForce;
            throwSound.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Rock hit: " + collision.gameObject.name); // Debugging

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Rock hit an enemy!");

            EnemyStun enemyStun = collision.GetComponent<EnemyStun>();
            if (enemyStun != null)
            {
                enemyStun.StunEnemy();
            }

            // Stop the rock and destroy it after a short delay
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            Destroy(gameObject, 1f);
        }
    }
}