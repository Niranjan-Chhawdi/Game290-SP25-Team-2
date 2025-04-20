using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class DoorButton : MonoBehaviour
{
    public bool isDoor = false;
    SpriteRenderer buttonSpriteRenderer;
    public GameObject door;
    public GameObject[] objectsToKill;
    public Sprite button;
    public Sprite buttonPressed;

    void Awake()
    {
        buttonSpriteRenderer = GetComponent<SpriteRenderer>();
        if (buttonSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on the GameObject.");
        }
        buttonSpriteRenderer.sprite = button;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        buttonSpriteRenderer.sprite = buttonPressed;
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

        if (isDoor)
        {
            SpriteRenderer doorRenderer = door.GetComponent<SpriteRenderer>();
            NavMeshObstacle navMeshObstacle = door.GetComponent<NavMeshObstacle>();
            navMeshObstacle.enabled = false;
            //set the opacity of the sprite to 0.5f
            doorRenderer.color = new Color(doorRenderer.color.r, doorRenderer.color.g, doorRenderer.color.b, 0.4f);
            Debug.Log("Player has entered the trigger area. NavMeshObstacle disabled.");
        }
    }
}
