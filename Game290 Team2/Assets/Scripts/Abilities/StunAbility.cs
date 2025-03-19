using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAbility : Ability
{
    public float stunDuration = 3f;
    public float stunRadius = 5f;
    public float cooldownTime = 10f;
    private float cooldownTimer = 0f;
   

    public override void Use(GameObject player)
    {
        if (cooldownTimer <= 0f)
        {
            Debug.Log("Stun Ability Used!");

            Collider2D[] enemies = Physics2D.OverlapCircleAll(player.transform.position, stunRadius);
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    EnemyStunV2 enemyStun = enemy.GetComponent<EnemyStunV2>();
                    if (enemyStun != null)
                    {
                        enemyStun.StunEnemy(stunDuration);
                    }
                }
            }

            cooldownTimer = cooldownTime;  // Reset cooldown
        }
        else
        {
            Debug.Log($"Ability on cooldown: {cooldownTimer} seconds remaining.");
        }
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