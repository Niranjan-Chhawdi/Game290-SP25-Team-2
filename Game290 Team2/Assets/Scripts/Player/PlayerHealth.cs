using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    PlayerController playerController;



    public float health;
    public float maxHealth;
    Image HP;

    Image Gas;
    public float maxOxygen = 100f;
    public float depletionRate = 5f;
    public float currentOxygen;


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
        agent = GetComponent<NavMeshAgent>();
        HP = GameObject.Find("HP").GetComponent<Image>();
        maxHealth = health;

        currentOxygen = maxOxygen;
        Gas = GameObject.Find("Gas").GetComponent<Image>();

        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        DepleteOxygen();
        HP.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

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

        if (isDead)
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }
    }

    public void refillAll()
    {
        health = maxHealth;
        currentOxygen = maxOxygen;
        HP.fillAmount = health / maxHealth;
        Gas.fillAmount = currentOxygen / maxOxygen;
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
        isWaitingToRespawn = true;
        respawnTimer = 3f;
    }

    void Respawn()
    {
        isDead = false;

        //set is to dynamic
        agent.isStopped = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        spriteRenderer.color = Color.white;
        playerController.hasKey = false;
        playerController.keyNum = 0;
        playerController.gunPieces = 0;
        playerController.hasGun = false;

        health = maxHealth;
        currentOxygen = maxOxygen;
        Debug.Log("Player Respawned!");
    }

    private void DepleteOxygen()
    {
        currentOxygen -= depletionRate * Time.deltaTime;
        if (currentOxygen < 0) currentOxygen = 0;

        Gas.fillAmount = currentOxygen / maxOxygen;

        if (currentOxygen == 0)
        {
            die();
        }
    }
    public void RefillOxygen(float amount)
    {
        currentOxygen += amount;
        if (currentOxygen > maxOxygen) currentOxygen = maxOxygen;

        Gas.fillAmount = currentOxygen / maxOxygen;
    }
    public void RefillHealth(float amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;

        HP.fillAmount = health / maxHealth;
    }


}