using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public bool isHiding = false;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    internal float normalized;
    public Ability dashAbility; 


    public Vector2 GetMovementDirection()
{
    return movement;
}


    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Movement.Dash.performed += ctx => ActivateDash();
    }

    private void OnDisable()
{
    playerControls.Movement.Dash.performed -= ctx => ActivateDash();
    playerControls.Disable();
}

private void ActivateDash()
{
    if (dashAbility != null)
    {
        dashAbility.Activate(gameObject);
    }
}


    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
    rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));

    // Rotate player based on movement direction
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90); // Adjust angle for correct facing
        }
    }
}
