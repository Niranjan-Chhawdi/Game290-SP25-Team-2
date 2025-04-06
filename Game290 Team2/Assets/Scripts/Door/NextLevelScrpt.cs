using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScrpt : MonoBehaviour
{
    Collider2D doorCollider;
    public string nextlevel;
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<Collider2D>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextlevel);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
