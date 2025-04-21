
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class BossExecution : MonoBehaviour
{
    public bool doExucution = false;
    bool goToDest2 = false;
    PlayerNavMesh playerNavMesh;
    AgentAnimation playerAnimation;
    Animator animatorPlayer;
    PlayerController playerController;
    NavMeshAgent agent;


    public Animator animatorBoss;
    public Collider2D col;
    public Transform dest;
    public Transform dest2;

    void Awake()
    {
        animatorPlayer = GetComponent<Animator>();
        playerNavMesh = GetComponent<PlayerNavMesh>();
        playerAnimation = GetComponent<AgentAnimation>();
        agent = GetComponent<NavMeshAgent>();
        playerController = GetComponent<PlayerController>();


    }

    void Update()
    {


        if (doExucution)
        {
            playerNavMesh.enabled = false;
            agent.SetDestination(dest.position);
            agent.stoppingDistance = 0.3f;

            if (!agent.pathPending && agent.remainingDistance < 0.4f)
            {


                agent.ResetPath();

                Debug.Log("Execution complete.");
                playerAnimation.enabled = false;
                //stop 

                animatorPlayer.Play("showGun");
                doExucution = false;
            }
        }
        if (goToDest2)
        {
            playerController.canNotBeTraced = true;
            playerController.isHiding = true;
            agent.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, dest2.position, 02f * Time.deltaTime);
        }

    }
    public void playBossDead()
    {
        animatorBoss.Play("bossDead");
    }


    public void goDest2()
    {
        goToDest2 = true;
    }





}
