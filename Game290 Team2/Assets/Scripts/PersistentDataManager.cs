using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    private static PersistentDataManager _instance;
    public static PersistentDataManager Instance { get { return _instance; } }
    private List<Ability> gainedAbilities = new List<Ability>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this manager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddAbility(Ability newAbility)
    {
        if (!gainedAbilities.Contains(newAbility))
        {
            gainedAbilities.Add(newAbility);
        }
    }

    public List<Ability> GetAllAbilities()
    {
        return gainedAbilities;
    }

    public bool HasAbility(Ability ability)
    {
        return gainedAbilities.Contains(ability);
    }
}