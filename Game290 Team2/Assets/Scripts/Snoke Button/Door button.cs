using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class DoorButton : MonoBehaviour
{
    public NavMeshObstacle navMeshObstacle;
    public SpriteRenderer spriteRenderer;
    public GameObject[] objectsToKill;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (objectsToKill != null)
        {
            foreach (GameObject obj in objectsToKill)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
        }

        if (other.CompareTag("Player") && navMeshObstacle != null)
        {

            navMeshObstacle.enabled = false;
            //set the opacity of the sprite to 0.5f
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.4f);
            Debug.Log("Player has entered the trigger area. NavMeshObstacle disabled.");
        }
    }
}
