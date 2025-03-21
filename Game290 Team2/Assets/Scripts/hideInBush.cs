using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideInBush : MonoBehaviour
{
    Collider2D bushCollider;
    SpriteRenderer spriteRenderer;
    public bool isHiding = false;

    // Start is called before the first frame update
    void Awake()
    {
        bushCollider = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            isHiding = true;
            //set the alpha of the player to 0.5
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //set the alpha of the player to 1
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            isHiding = false;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }
    }
}
