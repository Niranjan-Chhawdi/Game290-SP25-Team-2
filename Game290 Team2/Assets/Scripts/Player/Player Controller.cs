using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 1f;
    public AbilityManager abilityManager;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;


    void Start()
    {
        abilityManager = FindObjectOfType<AbilityManager>();

        if (abilityManager != null)
        {
            Debug.Log("AbilityManager found!");
        }
        else
        {
            Debug.LogError("AbilityManager not found in the scene.");
        }
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        // Check for input to use abilities
        if (Input.GetKeyDown(KeyCode.Alpha1))  // Press '1' to use Stun
        {
            abilityManager.UseAbility(0, gameObject);  // 0 is for StunAbility
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))  // Press '4' to use Teleport
        {
            abilityManager.UseAbility(1, gameObject);  // 1 is for TeleportAbility
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))  // Press '3' to use Remove Enemy
        {
            abilityManager.UseAbility(2, gameObject);  // 2 is for RemoveEnemyAbility
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))  // Press '2' to use Invisibility
        {
            abilityManager.UseAbility(3, gameObject);  // 3 is for InvisibilityAbility
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        // Capture movement input
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        // Apply movement to the rigidbody
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));

        // Rotate player based on movement direction
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90); // Adjust angle for correct facing
        }
    }
}