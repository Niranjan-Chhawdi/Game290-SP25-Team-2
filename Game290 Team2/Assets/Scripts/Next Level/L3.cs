using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L3 : MonoBehaviour
{
    Collider2D doorCollider;
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<Collider2D>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("123");
        if (collision.gameObject.tag == "Player")
        {
        	SceneManager.LoadScene("L3 Layer3");           
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
