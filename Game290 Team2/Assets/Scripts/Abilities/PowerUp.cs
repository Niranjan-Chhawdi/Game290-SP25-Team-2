using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference https://www.youtube.com/watch?v=PkNRPOrtyls&t=174s
public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player check here
        Destroy(gameObject);
        powerupEffect.Apply(collision.gameObject);
    }
}
