using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Zo2Buff")]
// Reference = https://www.youtube.com/watch?v=PkNRPOrtyls&t=174s

public class Zo2Buff : PowerupEffect
{

    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerOxygen>().maxOxygen += amount;
    }
}
