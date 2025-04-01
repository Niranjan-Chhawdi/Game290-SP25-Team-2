using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockInventory : MonoBehaviour
{
    public int rockCount = 0; 
    public TMP_Text rockUIText; 

    public void AddRock()
    {
        rockCount++;
        UpdateUI();
    }

    public void UseRock()
    {
        if (rockCount > 0)
        {
            rockCount--;
            UpdateUI();
        }
    }
    public void RemoveRock()
    {
        if (rockCount > 0)
        {
            rockCount--; 
            UpdateUI(); 
        }
    }
    private void UpdateUI()
    {
        if (rockUIText != null)
        {
            rockUIText.text = "Rocks: " + rockCount;
        }
    }
}
