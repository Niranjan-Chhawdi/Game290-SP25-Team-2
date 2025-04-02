using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Where I found this resource
/// https://www.youtube.com/watch?v=PkNRPOrtyls&t=174s
/// 

public abstract class PowerupEffect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
