using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executionTrigger : MonoBehaviour
{
    Collider2D col;
    GameObject player;
    BossExecution bossExecution;
    void Awake()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.Find("Player");
        bossExecution = player.GetComponent<BossExecution>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && bossExecution.doExucution == false)
        {
            Debug.Log("Player Entered Execution Trigger!");
            // Call the method to execute the boss execution logic
            bossExecution.doExucution = true;
        }

    }
}
