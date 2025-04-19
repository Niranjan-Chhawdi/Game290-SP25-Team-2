
using UnityEngine;

public class RBAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public string walkingUp = "mainChar-walkingUp";
    public string walkingDown = "mainChar-walkingDown";
    public string walkingLeft = "mainChar-walkingLeft";
    public string walkingRight = "mainChar-walkingRight";
    public string idle = "mainChar-idle";

    private string currentAnim = "";

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the player object.");
        }
    }

    void Update()
    {
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.magnitude > 0.1f)
        {
            Vector2 direction = velocity.normalized;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Horizontal movement
                if (direction.x > 0)
                    PlayAnimation(walkingRight);
                else
                    PlayAnimation(walkingLeft);
            }
            else
            {
                // Vertical movement
                if (direction.y > 0)
                    PlayAnimation(walkingUp);
                else
                    PlayAnimation(walkingDown);
            }
        }
        else
        {
            PlayAnimation(idle);
            Debug.Log("Idle Animation Played");
        }
    }

    void PlayAnimation(string newAnim)
    {
        if (currentAnim == newAnim) return;
        animator.Play(newAnim);
        currentAnim = newAnim;
    }
}
