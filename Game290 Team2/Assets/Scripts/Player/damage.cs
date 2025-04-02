using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 10f;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.health -= damage;
            }
        }
    }
}
