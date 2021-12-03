using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : Collidable
{
    // Escena del combate
    public string escenaCombate;

    // Al colisionar con algo
    protected override void OnCollide(Collider2D colision) {
        // Comprobar si es el jugador
        if (colision.name == "Player") {
            SceneManager.LoadScene(escenaCombate, LoadSceneMode.Single);
            gameObject.SetActive(false);
        }
    }
}
