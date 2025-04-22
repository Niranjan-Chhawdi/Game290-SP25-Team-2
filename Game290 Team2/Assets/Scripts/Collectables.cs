using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField]
    public bool isKey = false;
    public bool isFriend = false;
    private string playerTag = "Player";
    GameObject player;
    PlayerController playerController;
    PlayerHealth playerHealth;
    public PowerUpData powerUpData;
    public string AbilityName = "None";

    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        playerHealth = player.GetComponent<PlayerHealth>();

        if
        ((AbilityName == "dash" && powerUpData.EnableDash) ||
         (AbilityName == "invisible" && powerUpData.EnableInvisible) ||
         (AbilityName == "stunEnemy" && powerUpData.EnableStunEnemy) ||
         (AbilityName == "throwStone" && powerUpData.EnableThrowStone))
        {
            Destroy(gameObject);
        }

        audioManager = FindObjectOfType<AudioManager>();
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
                audioManager.PlaykeyCollectSound(); 
            }

            if (isFriend)
            {
                checkAbility(AbilityName);
                playerHealth.refillAll();
                audioManager.PlaykeyCollectSound(); 
            }
            Destroy(gameObject);
        }
    }

    void checkAbility(string ability)
    {
        if (ability == "dash")
        {
            powerUpData.EnableDash = true;
        }
        else if (ability == "invisible")
        {
            powerUpData.EnableInvisible = true;
        }
        else if (ability == "stunEnemy")
        {
            powerUpData.EnableStunEnemy = true;
        }
        else if (ability == "throwStone")
        {
            powerUpData.EnableThrowStone = true;
        }
        else
        {
            Debug.Log("No ability found");
        }
    }
}
