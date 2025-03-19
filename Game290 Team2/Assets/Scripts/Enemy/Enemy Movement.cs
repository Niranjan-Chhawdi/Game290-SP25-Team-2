using System.Collections;
using UnityEngine;

public class EnemyAIW : MonoBehaviour
{
    public Transform[] waypoints; // Patrol points
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionRange = 5f;
    public LayerMask playerLayer;
    public Transform player;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;

    void Update()
    {
        if (CanSeePlayer())
        {
            isChasing = true;
        }
        else if (isChasing && Vector2.Distance(transform.position, player.position) > detectionRange * 1.5f)
        {
            isChasing = false; // Stop chasing if player is too far
        }

        if (isChasing)
            ChasePlayer();
        else
            Patrol();
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    bool CanSeePlayer()
    {
        Vector2 direction = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRange, playerLayer);

        return hit.collider != null && hit.collider.CompareTag("Player");
    }
}