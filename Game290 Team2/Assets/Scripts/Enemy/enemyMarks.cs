using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class enemyMarks : MonoBehaviour
{
    public enemyDetector detector;
    public SpriteRenderer shocking;
    public SpriteRenderer confusing;
    public SpriteRenderer dizzy;
    NavMeshAgent agent;
    SpriteRenderer currentMark;
    public EnemyPathFinding enemyPathfinding;

    float timer = 2f;

    void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyPathfinding.currentMethod == EnemyPathFinding.ScoutMethod.chasing)
        {
            if (detector.timeOutOfSight == 0)
            {
                showMarker(shocking);
            }
            else if (detector.timeOutOfSight > 0)
            {
                showMarker(confusing);

            }
        }
        if (agent.isStopped == true)
        {
            showMarker(dizzy);
        }
        else
        {
            dizzy.color = new Color(dizzy.color.r, dizzy.color.g, dizzy.color.b, 0);
        }
    }
    void showMarker(SpriteRenderer marker)
    {
        if (currentMark == marker)
        {
            return;
        }
        if (currentMark != null)
        {

            currentMark.color = new Color(currentMark.color.r, currentMark.color.g, currentMark.color.b, 0);
        }
        currentMark = marker;
        currentMark.color = new Color(currentMark.color.r, currentMark.color.g, currentMark.color.b, 1);

    }
}