using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    PlayerController playerController;
    public float health;
    public float maxHealth;
    public Image healthBar;
    private Vector3 startPosition;
    NavMeshAgent agent;
    bool isDead = false;
    public Color hurtColor = new Color(1, 0.5f, 0.5f);

    private float hurtTimer = 0f;
    private bool isPlayingHurtAnimation = false;
    private float respawnTimer = 0f;
    private bool isWaitingToRespawn = false;
    void Awake()
    {
        maxHealth = health;
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0 && !isDead)
        {
            die();
        }

        if (isPlayingHurtAnimation)
        {
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0f)
            {
                spriteRenderer.color = Color.white;
                isPlayingHurtAnimation = false;
            }
        }

        if (isWaitingToRespawn)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0f)
            {
                Respawn();
                isWaitingToRespawn = false;
            }
        }
    }

    public void takeDamge(float damage)
    {
        if (health <= 0 || isDead) return;

        health -= damage;

        if (!isPlayingHurtAnimation)
        {
            isPlayingHurtAnimation = true;
            hurtTimer = 0.4f;
            spriteRenderer.color = hurtColor;
        }
    }

    void die()
    {
        if (isDead) return;
        isDead = true;

        transform.rotation = Quaternion.Euler(0, 0, 90);
        spriteRenderer.color = hurtColor;
        agent.isStopped = true;
        isWaitingToRespawn = true;
        respawnTimer = 3f;
    }

    void Respawn()
    {
        isDead = false;
        agent.isStopped = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        spriteRenderer.color = Color.white;
        playerController.hasKey = false;
        playerController.keyNum = 0;
        playerController.gunPieces = 0;
        playerController.hasGun = false;
        health = maxHealth;
        Debug.Log("Player Respawned!");
    }
}