using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerOxygen : MonoBehaviour
{
    public Image oxygenBar; 
    public float maxOxygen = 100f;
    public float depletionRate = 5f;

    private float currentOxygen;

    private void Start()
    {
        currentOxygen = maxOxygen;
        UpdateOxygenBar();
    }

    private void Update()
    {
        DepleteOxygen();
    }

    private void DepleteOxygen()
    {
        currentOxygen -= depletionRate * Time.deltaTime;
        if (currentOxygen < 0) currentOxygen = 0;

        UpdateOxygenBar();

        if (currentOxygen == 0)
        {
            HandleOxygenDepletion();
        }
    }

    private void UpdateOxygenBar()
    {
        oxygenBar.fillAmount = currentOxygen / maxOxygen;
    }

    private void HandleOxygenDepletion()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Player has run out of oxygen!");
        SceneManager.LoadScene(currentSceneName);
    }

    public void RefillOxygen(float amount)
    {
        currentOxygen += amount;
        if (currentOxygen > maxOxygen) currentOxygen = maxOxygen;

        UpdateOxygenBar();
    }
}