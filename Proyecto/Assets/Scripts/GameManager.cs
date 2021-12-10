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

    // Lista de combates
    public List<String> combates = new List<string> { "Mapa1Combate1" };

    // Audio
    public AudioSource musica;
    public AudioSource sonido;

    // Partida cargada
    public bool cargar = false;
    public float x;
    public float y;

    // Escena mapa actual
    public GameObject escena;
    public GameObject faderEscena;
    public Animator animatorEscena;

    // Combates terminados
    public Dictionary<string, bool> terminados = new Dictionary<string, bool>();

    // Orientación del personaje
    public string orientacion = "derecha";

    private void Start() {
        // No destruir reproductores de audio
        DontDestroyOnLoad(musica.gameObject);
        DontDestroyOnLoad(sonido.gameObject);
    }
}
