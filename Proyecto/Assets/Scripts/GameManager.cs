using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    // Variables de combate
    public int vidaJ1 = 100;
    public int vidaMaxJ1 = 100;
    public int velJ1 = 10;

    // Audio
    public AudioSource musica;
    public AudioSource sonido;

    // Partida cargada
    public bool cargar = false;
    public float x;
    public float y;

    private void Start() {
        // No destruir reproductores de audio
        DontDestroyOnLoad(musica.gameObject);
        DontDestroyOnLoad(sonido.gameObject);
    }
}
