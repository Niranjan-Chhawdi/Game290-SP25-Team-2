using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalStage : MonoBehaviour
{
    NavMeshObstacle navMeshObstacle;
    GameObject player;
    PlayerController playerController;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {

        if (navMeshObstacle != null && playerController.hasGun)
        {
            navMeshObstacle.enabled = false;
            spriteRenderer.color = new Color(1, 1, 1, 0.5f); // Make the door semi-transparent
            Debug.Log("Final Stage Unlocked");

        }
    }
}
