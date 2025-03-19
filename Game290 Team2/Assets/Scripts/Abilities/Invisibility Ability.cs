using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InvisibilityAbility : Ability
{
    public float vanishDuration = 5f;  // Fixed duration for invisibility
    public float cooldownTime = 10f;
    private float cooldownTimer = 0f;
    private bool isInvisible = false;

    public override void Use(GameObject player)
    {
        if (cooldownTimer <= 0f)
        {
            if (!isInvisible)
            {
                Debug.Log("Invisibility Activated!");

                // Make player invisible
                player.GetComponent<SpriteRenderer>().enabled = false; // Hide sprite
                player.GetComponent<Collider2D>().enabled = false;    // Disable collider

                // Optionally, you could disable enemy AI detection here if you have one
                // Example: Disable AI or line-of-sight logic here

                isInvisible = true;

                // Start the invisibility timer
                StartCoroutine(EndVanishDuration(player));

                cooldownTimer = cooldownTime;  // Reset cooldown
            }
            else
            {
                Debug.Log("Already invisible!");
            }
        }
        else
        {
            Debug.Log($"Ability on cooldown: {cooldownTimer} seconds remaining.");
        }
    }

    private IEnumerator EndVanishDuration(GameObject player)
    {
        yield return new WaitForSeconds(vanishDuration); // Wait for the vanish duration

        // Make the player visible again after the duration
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Collider2D>().enabled = true;

        isInvisible = false;
        Debug.Log("Invisibility Ended!");

        // Re-enable AI detection if you disabled it
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public override float GetCooldownTime()
    {
        return cooldownTimer > 0f ? cooldownTimer : 0f;
    }
}