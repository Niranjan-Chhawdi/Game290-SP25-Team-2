using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp/PowerUpData")]
public class PowerUpData : ScriptableObject
{
    public bool EnableDash = false;
    public bool EnableInvisible = false;
    public bool EnableStunEnemy = false;
    public bool EnableThrowStone = false;
}
