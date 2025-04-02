using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject secondObj;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objectToDestroy != null)
        {
            Destroy(objectToDestroy);
            Destroy(secondObj);
            Debug.Log("Smoke Screenoff!");
        }
    }
}
