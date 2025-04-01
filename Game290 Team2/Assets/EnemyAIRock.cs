using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    private bool isStunned = false;
    private float stunDuration = 2f;  // How long the enemy stays stunned

    // Call this method to stun the enemy
    public void StunEnemy()
    {
        if (!isStunned)
        {
            isStunned = true;
            Debug.Log("Enemy Stunned!");

            // You can add more logic here, like stopping the enemy's movement
            // For example, if you have a movement script for the enemy, you could disable it temporarily

            // Call UnstunEnemy after the stun duration
            Invoke(nameof(UnstunEnemy), stunDuration);
        }
    }

    private void UnstunEnemy()
    {
        isStunned = false;
        Debug.Log("Enemy Unstunned!");

        // Re-enable movement or any other behavior when the enemy is unstunned
    }

    // Optionally, you can use this method to check if the enemy is stunned
    public bool IsStunned()
    {
        return isStunned;
    }
}