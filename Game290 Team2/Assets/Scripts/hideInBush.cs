
using UnityEngine;

public class hideInBush : MonoBehaviour
{

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlayhideGrassSound();
            collision.GetComponent<PlayerController>().isHiding = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().isHiding = false;
        }

    }
}
