using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityUI : MonoBehaviour
{
    public TextMeshProUGUI[] abilityTexts;
    public AbilityManager abilityManager;

    void Start()
    {
        abilityManager = AbilityManager.Instance;
    }
    private void Update()
    {
        for (int i = 0; i < abilityManager.availableAbilities.Count; i++)
        {
            string abilityName = abilityManager.availableAbilities[i].GetType().Name;
            float cooldownTime = abilityManager.availableAbilities[i].GetCooldownTime();

            abilityTexts[i].text = $"{abilityName} - Cooldown: {cooldownTime:F1}s";
        }
    }
}