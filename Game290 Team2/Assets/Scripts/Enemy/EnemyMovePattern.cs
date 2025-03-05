using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePattern : MonoBehaviour
{
   private EnemyPathfinding enemyPathfinding;

    public float stepSize = 1f;
    public int totalSteps = 2; 
    public float stepDelay = 0.5f;

    private int currentStep = 0;
    private int directionIndex = 0; 

    private Vector2[] movementPattern = new Vector2[]
    {
        new Vector2(0, 1), 
        new Vector2(0, -1), 
        new Vector2(-1, 0), 
        new Vector2(1, 0)   
    };

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
    }

    private void Start()
    {
        StartCoroutine(MoveInPattern());
    }

    private IEnumerator MoveInPattern()
    {
        while (true)
        {
            Vector2 targetPosition = GetNextStepPosition();
            enemyPathfinding.MoveTo(targetPosition);
            currentStep++;

            
            if (currentStep >= totalSteps)
            {
                currentStep = 0; 
                directionIndex = (directionIndex + 1) % movementPattern.Length; 
            }

            yield return new WaitForSeconds(stepDelay);
        }
    }

    private Vector2 GetNextStepPosition()
    {
        Vector2 direction = movementPattern[directionIndex];
        return new Vector2(transform.position.x + (direction.x * stepSize), transform.position.y + (direction.y * stepSize));
    }
}
