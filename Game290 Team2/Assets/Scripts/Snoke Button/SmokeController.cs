using UnityEngine;

public class SomkeController : MonoBehaviour
{
    public GameObject objectToDestroy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objectToDestroy != null)
        {
            Destroy(objectToDestroy);
            Debug.Log("Smoke Screenoff!");
        }
    }
}
