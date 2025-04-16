using UnityEngine;

//reference =https://www.youtube.com/watch?v=ry4I6QyPw4E&t=12s

[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity = 10f;

    public override void Activate(GameObject parent)
    {
        PlayerController controller = parent.GetComponent<PlayerController>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

        if (controller != null && rb != null)
        {
            Vector2 direction = controller.GetMovementDirection();
            rb.AddForce(direction.normalized * dashVelocity, ForceMode2D.Impulse);
        }
    }
}
