using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class takeShip : MonoBehaviour
{
    float timer = 0f;
    float timeToWait = 4f; // Time to wait before destroying the object
    bool isWaiting = false;

    void Update()
    {
        if (isWaiting)
        {
            timer += Time.deltaTime;

            // shink
            float shrinkSpeed = 1.5f; // shinking speed
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, shrinkSpeed * Time.deltaTime);

            if (timer >= timeToWait)
            {
                Destroy(gameObject); // delete
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isWaiting = true;
        }
    }
}
