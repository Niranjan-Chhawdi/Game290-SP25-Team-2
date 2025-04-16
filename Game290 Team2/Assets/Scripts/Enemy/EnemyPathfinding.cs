using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFinding : MonoBehaviour
{
    NavMeshAgent agent;
    private Transform dest1;
    private Transform dest2;
    private Transform lastDest;
    public bool arrived = false;
    public float remainingDistance = 0.2f;
    public enum ScoutMethod
    {
        in2Spot,
        inACircle,
        chasing,
    }
    public ScoutMethod currentMethod = ScoutMethod.in2Spot;

    void Awake()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found in children of " + gameObject.name);
            return;
        }
        agent.updateRotation = false;

        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "dest1")
            {
                dest1 = child;
            }
            else if (child.name == "dest2")
            {
                dest2 = child;
            }
        }
        if (dest1 == null || dest2 == null)
        {
            Debug.LogError("Dest1 or Dest2 not found in children of " + gameObject.name);
            return;
        }


    }

    void Start()
    {
        agent.SetDestination(dest1.position);
    }
    // Update is called once per frame

    void Update()
    {
        remainingDistance = agent.remainingDistance;
        if (currentMethod == ScoutMethod.in2Spot)
        {
            setDest();
            if (arrived)
            {
                switchIn2Spots();
            }
        }
        else if (currentMethod == ScoutMethod.inACircle)
        {
            return;
        }
        else if (currentMethod == ScoutMethod.chasing)
        {
            return;
        }
    }



    void setDest()
    {
        if (agent.remainingDistance < 0.1f)
        {
            arrived = true;
        }
    }

    void switchIn2Spots()
    {
        if (lastDest == dest1)
        {
            lastDest = dest2;
            agent.SetDestination(dest2.position);
            arrived = false;
        }
        else if (lastDest == dest2)
        {
            lastDest = dest1;
            agent.SetDestination(dest1.position);
            arrived = false;
        }
        else
        {
            lastDest = dest1;
            agent.SetDestination(dest1.position);
            arrived = false;
        }

    }

}
