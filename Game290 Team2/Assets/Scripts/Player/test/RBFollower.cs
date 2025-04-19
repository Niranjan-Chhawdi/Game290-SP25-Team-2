using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBFollower : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject mouseIndicator;
    public Transform noiesyVisualizer;
    float rbSpeed = 1f;
    public float minSpeed = 6f;
    public float maxSpeed = 10f;

    float maxNoiseRadius = 8f; // Adjust this value to control the noise radius
    float minNoiseRadius = 12f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mouseIndicator = GameObject.Find("MouseIndicator");
    }

    // Update is called once per frame
    void Update()
    {
        SetIndicatorPos();
        rbSpeed = GetSpeed();
        rb.MovePosition(Vector2.MoveTowards(rb.position, mouseIndicator.transform.position, rbSpeed * Time.deltaTime));
    }

    float GetSpeed()
    {
        float distance = Vector3.Distance(transform.position, mouseIndicator.transform.position);
        float speed = Mathf.Lerp(minSpeed, maxSpeed, distance / 6f); // Adjust the divisor to control speed scaling
        float noiseRadius = Mathf.Lerp(maxNoiseRadius, minNoiseRadius, distance / 6f); // Adjust the divisor to control noise radius scaling
        noiesyVisualizer.localScale = new Vector3(noiseRadius, noiseRadius, 1f); // Set the scale of the noise range indicator
        return speed;
    }

    void SetIndicatorPos()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 10f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        worldPosition.z = 0;
        mouseIndicator.transform.position = worldPosition;
    }
}
