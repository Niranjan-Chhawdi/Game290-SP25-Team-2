using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cagedItem : MonoBehaviour
{
    PlayerController playerController;
    public GameObject collectable;
    bool collected = false;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerController.hasKey)
            {
                //dialog: you have to find the key first
                Debug.Log("You have to find the key first");
            }
            else
            {
                if (!collected)
                {
                    collected = true;
                    Destroy(collectable);
                    playerController.collectAGunPiece();
                    Debug.Log("cage opened");
                    //dialog: you have collected a gun piece
                }
            }
        }

    }
}
