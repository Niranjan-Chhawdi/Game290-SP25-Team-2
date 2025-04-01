using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyStunV2 : MonoBehaviour
{
    public float stunTime = 3f;
    private bool this_isStunned = false;
    private float stunTimer = 0f;
    private Rigidbody2D rb;
    private MonoBehaviour movementScript;  // Reference to movement script

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<MonoBehaviour>(); // Assuming movement script is attached to the same object
    }

    public void StunEnemy(float duration)
    {
        if (!this_isStunned)
        {
            this_isStunned = true;
            stunTimer = duration;

            // Stop movement by freezing Rigidbody2D's movement
            rb.velocity = Vector2.zero; // Stop the velocity
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Freeze Rigidbody2D

            // Disable movement script if attached (e.g., an AI movement script)
            if (movementScript != null)
            {
                movementScript.enabled = false;  // Disable the movement script
            }

            Debug.Log("Enemy stunned for " + duration + " seconds!");
        }
    }

    private void Update()
    {
        if (this_isStunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0f)
            {
                this_isStunned = false;

                // Resume movement after stun ends
                rb.constraints = RigidbodyConstraints2D.None; // Unfreeze Rigidbody2D
                if (movementScript != null)
                {
                    movementScript.enabled = true; // Re-enable the movement script
                }

                Debug.Log("Enemy is no longer stunned.");
            }
        }
    }
}