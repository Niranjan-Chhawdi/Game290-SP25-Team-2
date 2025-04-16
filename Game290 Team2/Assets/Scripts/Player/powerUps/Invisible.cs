using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    public bool startInvisible = false; // Flag to check if the player is invisible
    public float duration = 5f; // Duration of invisibility in seconds
    void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (startInvisible)
        {
            playerController.isHiding = true;
            duration -= Time.deltaTime; // Decrease the duration by the time passed since last frame
            if (duration <= 0)
            {
                // Reset the invisibility flag and duration
                startInvisible = false;
                playerController.isHiding = false;
                duration = 5f; // Reset to original duration
            }
        }
    }

    // call this to be invisible
    public void DoInvisible()
    {
        startInvisible = true;
    }
}
