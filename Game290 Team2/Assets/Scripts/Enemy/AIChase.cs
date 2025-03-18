using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;
    private Vector2 originalPosition;
    private bool returningBack = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < distanceBetween)
        {
            returningBack = false;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            transform.position = Vector2.MoveTowards(this.transform.position , player.transform.position , speed * Time.deltaTime);
        }
        // else if (!returningBack) {
        //     transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
        // }
    }
}
