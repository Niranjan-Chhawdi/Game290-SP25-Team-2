using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RockPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    private bool canPickup = false;
    private GameObject nearbyRock;

    public RockInventory rockInventory;

    public GameObject rockPrefab;
    public GameObject currentRock;
    public Transform throwpoint;
    public KeyCode throwKey = KeyCode.R;
    public AudioSource throwSound;
    public TextMeshProUGUI pickupPromptText;
    private object rockRb;

    private void Update()
    {
        if (canPickup && Input.GetKeyDown(pickupKey))
        {
            PickUpRock();
        }

        if (Input.GetKeyDown(throwKey) && currentRock != null)
        {
            ThrowRock();
        }

        if (canPickup && nearbyRock != null)
        {
            UpdatePickupPromptPosition();
        }
    }

    private void PickUpRock()
    {
        if (nearbyRock != null)
        {
            rockInventory.AddRock();
            currentRock = nearbyRock;

            Rigidbody2D rockRb = currentRock.GetComponent<Rigidbody2D>();
            rockRb.isKinematic = true;
            rockRb.gravityScale = 0;
            currentRock.transform.SetParent(transform);
            currentRock.transform.localPosition = Vector3.zero;
            canPickup = false;
            nearbyRock = null;

            Debug.Log("Rock Picked Up");
        }
    }

    private void ThrowRock()
    {
        if (currentRock != null)
        {
            currentRock.SetActive(true);
            currentRock.transform.SetParent(null);

            Rigidbody2D rockRb = currentRock.GetComponent<Rigidbody2D>();
            if (rockRb == null)
            {
                Debug.LogError("No Rigidbody2D found on the rock!");
                return;
            }

            rockRb.isKinematic = false; // Enable physics
            rockRb.gravityScale = 0;

            Vector2 throwDirection = transform.right * (transform.localScale.x > 0 ? 1:-1); // Change if needed
            float throwStrength = 10f;
            rockRb.velocity = throwDirection * throwStrength; // Apply force

            Debug.Log("Throwing rock with velocity: " + rockRb.velocity);

            // Call StopRockAfterDistance to ensure rock doesn't move infinitely
            StartCoroutine(StopRockAfterDistance(rockRb, 3.5f));

            // Remove rock from inventory
            rockInventory.RemoveRock();
            currentRock = null;
        }
    }

    private IEnumerator StopRockAfterDistance(Rigidbody2D rockRb, float maxDistance)
    {
        Vector2 initialPosition = rockRb.transform.position;

        // Continue checking the distance while the rock is moving
        while (Vector2.Distance(initialPosition, rockRb.transform.position) < maxDistance)
        {
            yield return null; // Wait for the next frame
        }

        // Once max distance is reached, stop the rock's movement
        rockRb.velocity = Vector2.zero;
        rockRb.isKinematic = true;  // Stop physics interaction once the rock has landed
    }


    private void UpdatePickupPromptPosition()
    {
        if (pickupPromptText != null && nearbyRock != null)
        {
            // Convert the world position of the rock to screen space
            Vector3 rockScreenPosition = Camera.main.WorldToScreenPoint(nearbyRock.transform.position);

            // Update the position of the prompt text
            pickupPromptText.transform.position = rockScreenPosition + new Vector3(0, 50, 0); // Adjust 50 to position the text above the rock
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            canPickup = true;
            nearbyRock = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            canPickup = false;
            nearbyRock = null;
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