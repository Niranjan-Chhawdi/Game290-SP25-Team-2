using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunEnemy : MonoBehaviour
{

    GameObject nearestEnemy;
    public bool doStun = false;
    public float duration = 5f;
    float timer;
    public float range = 5f;
    bool isStunning = false;
    // Start is called before the first frame update

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            // Check if the enemy is within range
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < range && distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        if (closestEnemy != null)
        {
            //Debug.Log("Closest enemy found: " + closestEnemy.name);
            return closestEnemy;
        }
        else
        {
            //Debug.Log("No enemy found");
            return null;
        }
    }
    float distance(Vector2 enemyPos)
    {
        return Vector2.Distance(enemyPos, transform.position);

    }


    // Update is called once per frame
    void Update()
    {
        if (doStun)
        {
            nearestEnemy = FindNearestEnemy();
            if (nearestEnemy != null)
            {
                nearestEnemy.GetComponent<EnemyBehavior>().PauseEnemy(duration);
            }
            else
            {
                Debug.Log("No enemy found");
                doStun = false;
            }
        }
    }
}
