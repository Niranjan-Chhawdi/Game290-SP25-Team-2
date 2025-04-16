using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPausing : MonoBehaviour
{
    NavMeshAgent agent;

    float countDown;


    bool startCountDown = false;
    public float pauseTime = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        startCountDown = false;
        countDown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDown)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                startCountDown = false;
                agent.isStopped = false;
            }
        }
    }

    public void PauseEnemy(float time)
    {
        countDown = time;
        agent.isStopped = true;
        startCountDown = true;

    }
}
