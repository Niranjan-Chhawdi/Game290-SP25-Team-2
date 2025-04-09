using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PlayerPathFinding : MonoBehaviour
{
    private GameObject mouseIndicator;
    private Transform player;


    void Awake()
    {
        mouseIndicator = GameObject.Find("MouseIndicator");
        if (mouseIndicator == null)
        {
            Debug.LogError("MouseIndicator not found in the scene.");
        }
        player = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 10f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        worldPosition.z = 0;
        mouseIndicator.transform.position = worldPosition;

        //move to mouse position
        if (Vector3.Distance(player.position, mouseIndicator.transform.position) > 0.1f)
        {
            player.position = Vector3.MoveTowards(player.position, mouseIndicator.transform.position, Time.deltaTime * 5f);
        }



    }

}
