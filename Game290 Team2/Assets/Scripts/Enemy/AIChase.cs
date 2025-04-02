using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    public LayerMask obstacleLayer;

    private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, obstacleLayer);

        bool playerIsHiding = player.GetComponent<PlayerController>().isHiding;

        if (distance < distanceBetween && hit.collider == null && !playerIsHiding)
        {
            Debug.DrawRay(transform.position, direction * distance, Color.green);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Debug.DrawRay(transform.position, direction * distance, Color.red);
        }
    }
}
