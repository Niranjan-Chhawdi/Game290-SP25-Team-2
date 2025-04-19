using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
public enum PlayerState
{
    walking, usingAbility, dead
}
public class AgentAnimation : MonoBehaviour
{
    PlayerState playerState;
    Animator animator;
    NavMeshAgent agent;
    public string walkingUp = "mainChar-walkingUp";
    public string walkingDown = "mainChar-walkingDown";
    public string walkingLeft = "mainChar-walkingLeft";
    public string walkingRight = "mainChar-walkingRight";
    public string idle = "mainChar-idle";
    void Awake()
    {
        playerState = PlayerState.walking;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the player object.");
        }
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on the player object.");
        }
    }
    void Update()
    {
        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        if (playerState == PlayerState.walking)
        {
            Vector3 velocity = agent.velocity;
            if (velocity.magnitude > 0.1f)
            {
                Vector3 direction = velocity.normalized;

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    //horizontal movement
                    if (direction.x > 0)
                        animator.Play(walkingRight);
                    else
                        animator.Play(walkingLeft);
                }
                else
                {
                    // vertical movement
                    if (direction.y > 0)
                        animator.Play(walkingUp);
                    else
                        animator.Play(walkingDown);
                }
            }
            else
            {
                // idle
                animator.Play(idle);
            }
        }
    }

}