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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {

            EnemyStun enemyStun = collision.collider.GetComponent<EnemyStun>();
            if (enemyStun != null)
            {
                enemyStun.StunEnemy();
            }
        }
    }
}
