using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    private bool isStunned = false;
    private float stunDuration = 2f;  

 
    public void StunEnemy()
    {
        if (!isStunned)
        {
            isStunned = true;
            Debug.Log("Enemy Stunned!");

            
            Invoke(nameof(UnstunEnemy), stunDuration);
        }
    }

    private void UnstunEnemy()
    {
        isStunned = false;
        Debug.Log("Enemy Unstunned!");

        
    }

    
    public bool IsStunned()
    {
        return isStunned;
    }
}