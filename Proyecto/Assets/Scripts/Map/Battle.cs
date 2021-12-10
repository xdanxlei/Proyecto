using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : Collidable
{
    // Sonidos
    public AudioClip batalla;

    // Starter
    public GameObject starter;

    // Objetos a parar
    public GameObject escena;

    // Animator del fade in
    public GameObject fader;
    public Animator animator;    

    // Al colisionar con algo
    protected override void OnCollide(Collider2D colision) {
        // Comprobar si es el jugador
        if (colision.name == "Player") {
            // Pausar escena
            gameObject.SetActive(false);
            GameManager.instance.escena = escena;
            GameManager.instance.faderEscena = fader;
            GameManager.instance.animatorEscena = animator;

            // Iniciar escena combate
            GameManager.instance.musica.Stop(); 
            GameManager.instance.sonido.PlayOneShot(batalla); 
            starter.gameObject.SetActive(true);
        }
    }
}
