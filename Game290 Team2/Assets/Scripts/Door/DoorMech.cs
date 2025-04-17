using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DoorMech : MonoBehaviour
{
    bool doorLocked = true;
    public Transform respawnPoint;
    PlayerController playerController;
    NavMeshObstacle navMeshObstacle;


    // Start is called before the first frame update
    void Awake()
    {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshObstacle != null && playerController.hasKey && playerController.keyNum > 0)
        {
            if (doorLocked)
            {
                navMeshObstacle.enabled = false;
                Debug.Log("Door Unlocked");
                doorLocked = false;
            }

        }
    }
    void Respawn(GameObject player)
    {
        if (respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;
            Debug.Log("Player Respawned!");
        }
        else
        {
            Debug.LogError("Respawn Point not set!");
        }
    }
}
