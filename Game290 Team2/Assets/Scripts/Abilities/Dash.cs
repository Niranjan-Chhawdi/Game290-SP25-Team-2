using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference =https://www.youtube.com/watch?v=ry4I6QyPw4E&t=12s

[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerController movement = parent.GetComponent<PlayerController>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();

        //rigidbody.velocity = movement.normalized
           // * dashVelocity;
    }
}
