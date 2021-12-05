using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproduceMusica : MonoBehaviour
{
    // Música
    public AudioClip musica;

    // Start is called before the first frame update
    void Start()
    {
        // Cambiar música
        GameManager.instance.musica.clip = musica;

        // Reproducir música
        GameManager.instance.musica.Play();
    }
}
