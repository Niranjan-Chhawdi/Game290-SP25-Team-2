using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;

public class enemyDetector : MonoBehaviour
{
    private float timeOutOfSight = 0f;
    public float giveUpTime = 5f;
    public float searchRadius = 5f;

    NavMeshAgent agent;
    private Transform player;
    private PlayerController playerController;
    private float distance;
    public LayerMask obstacleLayer;
    public enemyPathFinding pathFinding;


    void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found in parent of " + gameObject.name);
            return;
        }
        agent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found on player object.");
            return;
        }
    }

    void Update()
    {
        if (pathFinding.currentMethod == enemyPathFinding.ScoutMethod.chasing)
        {
            agent.SetDestination(player.position);
        }

        bool inSight = CheckingIfInSight(player.position);

        if (inSight)
        {
            pathFinding.currentMethod = enemyPathFinding.ScoutMethod.chasing;
            agent.SetDestination(player.position);
            timeOutOfSight = 0f; // reset the timer when the player is in sight
        }
        else if (!inSight)
        {
            timeOutOfSight += Time.deltaTime;
            if (timeOutOfSight % 1 == 0)
            {
                Debug.Log("Player out of sight for: " + timeOutOfSight);
            }

            if (timeOutOfSight >= giveUpTime)
            {
                // stop chasing the player after certain time
                pathFinding.currentMethod = enemyPathFinding.ScoutMethod.in2Spot;
                timeOutOfSight = 0f;
            }
        }
    }


    private bool CheckingIfInSight(Vector3 target)
    {
        // Check if the player is within the search radius and not hiding
        if (playerController.isHiding)
        {
            return false;
        }

        if (DistanceToPlayer() < searchRadius)
        {
            Vector2 origin = transform.position;
            Vector2 direction = ((Vector2)target - origin).normalized;
            float d = Vector2.Distance(origin, target);
            Debug.DrawRay(origin, direction * 15, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, d, obstacleLayer);
            if (hit.collider != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else // not within search radius
        {
            return false;
        }
    }
    private float DistanceToPlayer()
    {
        return Vector2.Distance(transform.position, player.position);
    }

}
