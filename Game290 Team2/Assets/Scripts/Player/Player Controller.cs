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
    internal float normalized;
    public Ability dashAbility;


    public Vector2 GetMovementDirection()
    {
        return movement;
    }


    private void Awake()
    {
        playerControls = new PlayerControls();
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
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }


}
