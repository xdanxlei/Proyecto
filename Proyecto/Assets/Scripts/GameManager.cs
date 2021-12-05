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
    public static Battler jugador = new Battler(100, 100, 10);

    // Audio
    public AudioSource musica;
    public AudioMixer musMix;
    public AudioSource sonido;
    public AudioMixer soMix;

    private void Start() {
        // No destruir reproductores de audio
        DontDestroyOnLoad(musica.gameObject);
        DontDestroyOnLoad(sonido.gameObject);
    }
}
