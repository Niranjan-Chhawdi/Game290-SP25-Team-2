using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHidingDetector : MonoBehaviour
{
    public bool isHiding = false; // Variable to check if the player is hiding
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("canHideIn"))
        {
            Debug.Log("Player is hiding in " + collision.gameObject.name);
            isHiding = true; // Set the hiding state to true when entering the trigger
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("canHideIn"))
        {
            Debug.Log("Player is hiding in " + collision.gameObject.name);
            isHiding = true; // Set the hiding state to true when entering the trigger
        }
    }
}
