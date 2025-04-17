using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2 : MonoBehaviour
{
    public PlayerController playerController;
    public int keyToExit = 1;
    Collider2D doorCollider;
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerController.keyNum >= keyToExit)
        {
            SceneManager.LoadScene("L3 Layer 2");
        }


    }
}


