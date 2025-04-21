using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PlayerNavMesh : MonoBehaviour
{
    private GameObject mouseIndicator;
    private NavMeshAgent agent;
    public Transform noiesyIndicator;
    public bool isStraight = false;
    bool starting = false;


    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    float maxNoiseRadius = 8f; // Adjust this value to control the noise radius
    float minNoiseRadius = 12f;

    void Awake()
    {
        mouseIndicator = GameObject.Find("MouseIndicator");
        if (mouseIndicator == null)
        {
            Debug.LogError("MouseIndicator not found in the scene.");
        }
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && !starting)
        {
            starting = true;
            agent.SetDestination(mouseIndicator.transform.position);
        }

        agent.speed = GetSpeed();
        updateIndicatorPosition();

        if (isStraight && starting)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = mouseIndicator.transform.position;
            float distance = Vector2.Distance(currentPos, targetPos);

            if (distance > 0.6f)
            {
                // stop
                if (agent.hasPath) agent.ResetPath();

                // calculate direction
                Vector2 direction = (targetPos - currentPos).normalized;

                // calculate the angle between the current direction and the target direction
                agent.velocity = direction * agent.speed;
            }
            else
            {
                agent.velocity = Vector2.zero;
                agent.ResetPath();
            }
        }


    }

    float GetSpeed()
    {
        float distance = Vector3.Distance(transform.position, mouseIndicator.transform.position);
        float speed = Mathf.Lerp(minSpeed, maxSpeed, distance / 6f); // Adjust the divisor to control speed scaling
        float noiseRadius = Mathf.Lerp(minNoiseRadius, maxNoiseRadius, distance / 6f); // Adjust the divisor to control noise radius scaling
        noiesyIndicator.localScale = new Vector3(noiseRadius, noiseRadius, 1f); // Set the scale of the noise range indicator
        return speed;
    }

    void updateIndicatorPosition()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 10f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        worldPosition.z = 0;
        mouseIndicator.transform.position = worldPosition;
    }
}
