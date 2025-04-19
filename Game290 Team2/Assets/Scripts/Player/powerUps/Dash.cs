using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dash : MonoBehaviour
{
    NavMeshAgent agent;
    public bool startDashing = false;
    Vector2 directionToMouse;


    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            // Debug.LogError("NavMeshAgent not found on Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startDashing)
        {
            Vector2 dashDirection = getMouseDirection();
            agent.Move(dashDirection * 4f); // Move the player in the direction of the mouse with a speed of 5 units
            startDashing = false; // Reset the dashing state after moving
        }
    }
    Vector2 getMouseDirection()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        directionToMouse = (mousePos - playerPos).normalized;
        return directionToMouse;
    }
    public void DoDash()
    {
        startDashing = true;
    }
}