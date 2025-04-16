using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class enemyMarks : MonoBehaviour
{
    public enemyDetector detector;
    public GameObject shocking;
    public GameObject confusing;
    public GameObject dizzy;
    NavMeshAgent agent;
    GameObject currentMark;
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
            dizzy.SetActive(false);
        }
    }
    void showMarker(GameObject marker)
    {
        if (currentMark == marker)
        {
            return;
        }
        if (currentMark != null)
        {
            currentMark.SetActive(false);
        }
        currentMark = marker;
        currentMark.SetActive(true);

    }
}
