using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> availableAbilities = new List<Ability>();  // List of unlocked abilities
    public static AbilityManager Instance;
    void Start()
    {
        // Example: Initially add abilities if needed
        availableAbilities.Add(new StunAbility());  // First ability unlocked at start (for example)
        availableAbilities.Add(new TeleportAbility());  // Second ability
        availableAbilities.Add(new RemoveEnemyAbility());  // Third ability
        availableAbilities.Add(new InvisibilityAbility());  // Fourth ability
    }

    // Call this method to use an ability (from PlayerController)
    public void UseAbility(int index, GameObject player)
    {
        if (index >= 0 && index < availableAbilities.Count)
        {
            availableAbilities[index].Use(player);
        }
    }

    // Saving and loading abilities (for persistence)
    public void SaveAbilities()
    {
        PlayerPrefs.SetInt("HasStunAbility", availableAbilities.Any(a => a is StunAbility) ? 1 : 0);
        PlayerPrefs.SetInt("HasTeleportAbility", availableAbilities.Any(a => a is TeleportAbility) ? 1 : 0);
        PlayerPrefs.SetInt("HasRemoveEnemyAbility", availableAbilities.Any(a => a is RemoveEnemyAbility) ? 1 : 0);
        PlayerPrefs.SetInt("HasInvisibilityAbility", availableAbilities.Any(a => a is InvisibilityAbility) ? 1 : 0);
    }

    public void LoadAbilities()
    {
        availableAbilities.Clear(); // Prevent duplicates

        if (PlayerPrefs.GetInt("HasStunAbility") == 1) availableAbilities.Add(new StunAbility());
        if (PlayerPrefs.GetInt("HasTeleportAbility") == 1) availableAbilities.Add(new TeleportAbility());
        if (PlayerPrefs.GetInt("HasRemoveEnemyAbility") == 1) availableAbilities.Add(new RemoveEnemyAbility());
        if (PlayerPrefs.GetInt("HasInvisibilityAbility") == 1) availableAbilities.Add(new InvisibilityAbility());
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}