using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference = https://www.youtube.com/watch?v=JmLIxXiKFqI&t=319s

public class CutSceneInitiator : MonoBehaviour
{
    private CutSceneHandler CutSceneHandler;

    public void Start()
    {
        CutSceneHandler = GetComponent<CutSceneHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
             CutSceneHandler.PlayNextElement();
    }
}
