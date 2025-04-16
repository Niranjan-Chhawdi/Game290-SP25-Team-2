using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PlayerNavMesh : MonoBehaviour
{
    private GameObject mouseIndicator;
    private NavMeshAgent agent;
    public Transform noiesyRange;
    float minSpeed = 2f;
    float maxSpeed = 5f;
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
        agent.SetDestination(mouseIndicator.transform.position);
    }

    void Update()
    {
        agent.speed = GetSpeed();
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 10f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        worldPosition.z = 0;
        mouseIndicator.transform.position = worldPosition;

        if (agent.destination != mouseIndicator.transform.position)
        {
            agent.SetDestination(mouseIndicator.transform.position);
        }
    }
    float GetSpeed()
    {
        float distance = Vector3.Distance(transform.position, mouseIndicator.transform.position);
        float speed = Mathf.Lerp(minSpeed, maxSpeed, distance / 6f); // Adjust the divisor to control speed scaling
        float noiseRadius = Mathf.Lerp(maxNoiseRadius, minNoiseRadius, distance / 6f); // Adjust the divisor to control noise radius scaling
        noiesyRange.localScale = new Vector3(noiseRadius, noiseRadius, 1f); // Set the scale of the noise range indicator
        return speed;
    }
}
