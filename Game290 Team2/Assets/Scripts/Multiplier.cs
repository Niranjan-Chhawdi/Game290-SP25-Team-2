using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Multiplier : MonoBehaviour
{
    public Transform multiPoint;
    public GameObject box;
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(box , multiPoint.position, transform.rotation);
        }
    }
}
