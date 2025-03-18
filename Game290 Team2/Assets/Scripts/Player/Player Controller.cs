// Used Some library :)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake() {
        //Used the unity PlayerControls
        playerControls = new PlayerControls();
        // took the Rigid body from the scene
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        // Used the Unity Input System
        PlayerInput();
    }

    private void FixedUpdate() {
        // Now finally our player Moving
        Move();
    }

    private void PlayerInput() {
        // created the movement action map
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move() {
        // now changing the value of the position
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}

