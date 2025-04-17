using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";
    PlayerController playerController;
    public AbilityManager abilityManager;
    public bool isKey = false;
    public bool isFriend = false;
    public string AbilityName = "None";


    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found on Player GameObject.");
        }

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
