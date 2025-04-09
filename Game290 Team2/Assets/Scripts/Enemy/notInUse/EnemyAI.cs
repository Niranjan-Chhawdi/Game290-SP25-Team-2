using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private EnemyPathfinding enemyPathfinding;

    public float stepSize = 1f;
    public int totalSteps = 3;
    public float stepDelay = 0.5f;

    private bool movingUp = true;
    private int currentStep = 0;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
    }

    private void Start()
    {
        StartCoroutine(MoveInSteps());
    }

    private IEnumerator MoveInSteps()
    {
        while (true)
        {
            Vector2 targetPosition = GetNextStepPosition();
            enemyPathfinding.MoveTo(targetPosition);
            currentStep++;


            if (currentStep >= totalSteps)
            {
                movingUp = !movingUp;
                currentStep = 0;
            }

            yield return new WaitForSeconds(stepDelay);
        }
    }

    private Vector2 GetNextStepPosition()
    {
        float stepMovement = movingUp ? stepSize : -stepSize;
        return new Vector2(transform.position.x, transform.position.y + stepMovement);
    }
}
