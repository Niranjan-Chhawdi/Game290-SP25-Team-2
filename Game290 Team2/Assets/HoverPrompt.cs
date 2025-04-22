using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class HoverPrompt : MonoBehaviour
{
    public TMP_Text promptText; 
    private bool isNearRock = false;
  


    private void Start()
    {
 
        promptText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isNearRock && Input.GetKeyDown(KeyCode.E))
        {
           
            Debug.Log("Rock picked up!");
            promptText.gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            isNearRock = true;
            promptText.gameObject.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            isNearRock = false;
            promptText.gameObject.SetActive(false); 
        }
    }
}
