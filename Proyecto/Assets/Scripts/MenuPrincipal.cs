using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuPrincipal : MonoBehaviour
{
    // Constantes
    const string PRIMER_MAPA = "Primer mapa";
    const string KEY_MUSICA = "VolumenMusica";
    const string KEY_SONIDO = "VolumenSonido";
    const string KEY_PARTIDA_1 = "Partida1";
    const string KEY_PARTIDA_2 = "Partida2";
    const string KEY_PARTIDA_3 = "Partida3";

    // Objetos
    public GameObject menu;
    public GameObject menuContinuar;
    public GameObject menuOpciones;
    public GameObject menuSalir;
    public Button botonCargar;
    public Button botonPartida1;
    public Button botonPartida2;
    public Button botonPartida3;

    // Sonidos
    public AudioClip botonEn;
    public AudioClip botonPos;
    public AudioClip botonNeg;

    // Sliders
    public Slider musica;
    public Slider sonido;

    // Start is called before the first frame update
    void Start()
    {
        // Cambiar sliders
        Sliders();

        // Reproducir música
        GameManager.instance.musica.Play();

        // Comprobar si hay partidas guardadas
        ComprobarPartidas();
    }

    // Cambiar sliders
    private void Sliders(){
        if (PlayerPrefs.HasKey(KEY_MUSICA)){
            musica.value = PlayerPrefs.GetFloat(KEY_MUSICA);
        }
        if (PlayerPrefs.HasKey(KEY_SONIDO)){
            sonido.value = PlayerPrefs.GetFloat(KEY_SONIDO);
        }
    }

    // Comprobar si hay partidas guardadas
    private void ComprobarPartidas(){
        if (PlayerPrefs.HasKey(KEY_PARTIDA_1)){
            botonCargar.interactable = true;
            botonPartida1.interactable = true;
        }
        if (PlayerPrefs.HasKey(KEY_PARTIDA_2)){
            botonCargar.interactable = true;
            botonPartida2.interactable = true;
        }
        if (PlayerPrefs.HasKey(KEY_PARTIDA_3)){
            botonCargar.interactable = true;
            botonPartida3.interactable = true;
        }
    }

    // Función para abrir el menú de opciones
    public void opciones(){
        menu.gameObject.SetActive(false);
        menuOpciones.gameObject.SetActive(true);
    }

    // Función para abrir el menú de partidas
    public void abrirMenuContinuar(){
        menu.gameObject.SetActive(false);
        menuContinuar.gameObject.SetActive(true);
    }

    // Función para abrir el menú finalizar juego
    public void salir(){
        menu.gameObject.SetActive(false);
        menuSalir.gameObject.SetActive(true);
    }

    // Función para abrir el menú de opciones y cerrar los demás
    public void volver(){
        menu.gameObject.SetActive(true);
        menuContinuar.gameObject.SetActive(false);
        menuOpciones.gameObject.SetActive(false);
        menuSalir.gameObject.SetActive(false);
    }

    // Función para cerrar el juego
    public void quit(){
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }

    // Iniciar una nueva partida
    public void nuevaPartida(){
        SceneManager.LoadScene(PRIMER_MAPA, LoadSceneMode.Single);
    }

    // Cargar partida anteriormente guardada
    public void cargarPartida(string partida){
        // Cargar partida
        GameManager.instance.cargar = true;

        // Nombre de la partida
        string nombrePartida = "Partida" + partida;

        // Recuperar datos
        GameManager.instance.vidaJ1 = PlayerPrefs.GetInt(nombrePartida + "VidaJ1");
        GameManager.instance.vidaMaxJ1 = PlayerPrefs.GetInt(nombrePartida + "VidaMaxJ1");
        GameManager.instance.velJ1 = PlayerPrefs.GetInt(nombrePartida + "VelocidadJ1");
        GameManager.instance.x = PlayerPrefs.GetFloat(nombrePartida + "PosicionX");
        GameManager.instance.y = PlayerPrefs.GetFloat(nombrePartida + "PosicionY");
        string mapa = PlayerPrefs.GetString(nombrePartida + "Escena");
        foreach (string clave in GameManager.instance.combates)
        {
            bool terminado = PlayerPrefs.HasKey(nombrePartida + clave);
            GameManager.instance.terminados.Add(clave, terminado);
        }

        // Ir al primer mapa
        SceneManager.LoadScene(mapa, LoadSceneMode.Single);
    }

    // Sonidos
    public void botonEnter(){
        GameManager.instance.sonido.PlayOneShot(botonEn);
    }

    public void botonPositive(){
        GameManager.instance.sonido.PlayOneShot(botonPos);
    }

    public void botonNegative(){
        GameManager.instance.sonido.PlayOneShot(botonNeg);        
    }
}
