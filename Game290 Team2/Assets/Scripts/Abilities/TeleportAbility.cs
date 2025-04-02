using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : Ability
{
    public float teleportDistance = 10f;  // How far to teleport

    public override void Use(GameObject player)
    {
        // Teleport the player in the direction they are facing
        Vector3 teleportDirection = player.transform.right * teleportDistance;  // Assuming the player faces right
        player.transform.position += teleportDirection;

        Debug.Log("Teleport Ability Used! Teleported by " + teleportDistance + " units.");
    }
}
