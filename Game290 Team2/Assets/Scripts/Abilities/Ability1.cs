using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability1 : MonoBehaviour

{
    public string abilityName;
    public Sprite abilityIcon;

    // Abstract method to be overridden by specific ality classes (like Stun, Teleport)
    public abstract void Use(GameObject player);
}
