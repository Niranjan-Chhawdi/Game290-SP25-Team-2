using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PlayerPathFinding : MonoBehaviour
{
    public GameObject mouseIndicator;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.SetDestination(mouseIndicator.transform.position);
    }

    void Update()
    {
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

}
