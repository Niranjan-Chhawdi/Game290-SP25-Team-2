using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour 
{
    public string abilityName;
    public Sprite abilityIcon;

    // Abstract method to be overridden by specific ability classes (like Stun, Teleport)
    public abstract void Use(GameObject player);


    public virtual float GetCooldownTime()
    {
        return 0f;
    }
}