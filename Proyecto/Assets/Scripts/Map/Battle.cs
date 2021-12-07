using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : Collidable
{
    // Escena del combate
    public string escenaCombate;

    // Objetos a parar
    public GameObject escena;

    // Al colisionar con algo
    protected override void OnCollide(Collider2D colision) {
        // Comprobar si es el jugador
        if (colision.name == "Player") {
            // Pausar escena
            gameObject.SetActive(false);
            escena.gameObject.SetActive(false);
            GameManager.instance.escena = escena;

            // Iniciar escena combate
            SceneManager.LoadScene(escenaCombate, LoadSceneMode.Additive);
        }
    }
}
