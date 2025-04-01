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

            // Calculate the direction using Atan2 for top-down movement
            Vector2 throwDirection = GetThrowDirection(); // Get the throw direction based on the player's facing direction

            if (throwDirection == Vector2.zero)
            {
                throwDirection = transform.up; // Default to up if no direction is available
            }

            float throwStrength = 10f;
            rockRb.velocity = throwDirection * throwStrength; // Apply force to the rock

            Debug.Log("Throwing rock in direction: " + throwDirection);

            // Call StopRockAfterDistance to ensure the rock doesn't move infinitely
            StartCoroutine(StopRockAfterDistance(rockRb, 3.5f));

            // Remove rock from inventory
            rockInventory.RemoveRock();
            currentRock = null;
        }
    }

    private Vector2 GetThrowDirection()
    {
        // Get the player's movement direction using Atan2 or transform-based method
        Vector2 movement = transform.up; // Default to facing up

        if (movement != Vector2.zero)
        {
            // Using Atan2 to calculate the direction
            float angle = Mathf.Atan2(movement.y, movement.x); // Angle in radians
            movement = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); // Get the unit vector for the direction
        }

        return movement;
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