using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isHiding = false;
    internal float normalized;
    public bool canNotBeTraced = false;
    SpriteRenderer spriteRenderer;

    public bool hasKey = false;
    public int keyNum = 0;

    bool hasGun = false;
    int gunPieces = 0;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {

        if (isHiding)
        {
            HidePlayer();
        }
        else
        {
            ShowPlayer();
        }



    }

    void HidePlayer()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

    }
    void ShowPlayer()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
    }

    public void collectAGunPiece()
    {
        gunPieces++;
        if (gunPieces == 4 && !hasGun)
        {
            hasGun = true;
            Debug.Log("You have collected a gun!");

        }
    }
}