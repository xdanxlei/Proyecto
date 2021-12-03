using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Collidable
{
    // Al colisionar con algo
    protected override void OnCollide(Collider2D colision) {
        // Comprobar si es el jugador
        if (colision.name == "Player") {
            //Debug.Log("coll");
        }
    }
}
