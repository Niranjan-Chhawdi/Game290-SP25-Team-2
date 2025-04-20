using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    public bool isKey = false;
    public bool isFriend = false;
    private string playerTag = "Player";
    public GameObject player;
    PlayerController playerController;
    PlayerHealth playerHealth;
    public AbilityManager abilityManager;
    public string AbilityName = "None";

    private void Start()
    {
        player = GameObject.Find("Player");

        playerController = player.GetComponent<PlayerController>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            if (isKey)
            {
                playerController.hasKey = true;
                playerController.keyNum++;
                Debug.Log("Got Key!");
            }

            if (isFriend)
            {
                checkAbility(AbilityName);
                playerHealth.refillAll();
            }
            Destroy(gameObject);
        }
    }

    void checkAbility(string ability)
    {
        if (ability == "dash")
        {
            abilityManager.EnableDash = true;
        }
        else if (ability == "invisible")
        {
            abilityManager.EnableInvisible = true;
        }
        else if (ability == "stunEnemy")
        {
            abilityManager.EnableStunEnemy = true;
        }
        else if (ability == "throwStone")
        {
            abilityManager.EnableThrowStone = true;
        }
        else
        {
            Debug.Log("No ability found");
        }
    }
}
