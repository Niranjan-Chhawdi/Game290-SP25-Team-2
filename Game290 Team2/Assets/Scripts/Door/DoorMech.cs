using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMech : MonoBehaviour
{
     public Transform respawnPoint; 
    public GameObject Key;
    public BoxCollider2D boxCollider;

    private bool isColliderDisabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
    }   

    // Update is called once per frame
    void Update()
    {
        if (Key == null && boxCollider != null && !isColliderDisabled)
        {
            boxCollider.enabled = false;
            isColliderDisabled = true;
            Debug.Log("Door Unlocked");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isColliderDisabled) 
        {
            Respawn(other.gameObject);
        }
    }

    void Respawn(GameObject player)
    {
        if (respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;
            Debug.Log("Player Respawned!");
        }
        else
        {
            Debug.LogError("Respawn Point not set!");
        }
    }
}
