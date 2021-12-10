using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuPausa : MonoBehaviour
{
    // Constantes
    const string KEY_MUSICA = "VolumenMusica";
    const string KEY_SONIDO = "VolumenSonido";

    // Objetos
    public GameObject menuPausa;
    public GameObject menuGuardar;
    public GameObject menuOpciones;
    public GameObject menuSalir;
    public GameObject menuVolverAMain;
    public GameObject menuConfirmarSalir;
    public GameObject gear;
    public GameObject fade;

    // Sonidos
    public AudioClip botonEn;
    public AudioClip botonPos;
    public AudioClip botonNeg;

    // Sliders
    public Slider musica;
    public Slider sonido;

    // Nombre de la escena actual
    public string escena;

    // Jugador
    public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        // Cambiar sliders
        if (PlayerPrefs.HasKey(KEY_MUSICA)){
            musica.value = PlayerPrefs.GetFloat(KEY_MUSICA);
        }
        if (PlayerPrefs.HasKey(KEY_SONIDO)){
            sonido.value = PlayerPrefs.GetFloat(KEY_SONIDO);
        }
    }

    // Función para volver al juego
    public void reanudar(){
        // Reanudar escena
        Time.timeScale = 1;
        menuPausa.gameObject.SetActive(false);
        gear.gameObject.SetActive(true);
    }

    // Función para abrir el menú de guardar partida
    public void menuGuardarPartida() {
        menuPausa.gameObject.SetActive(false);
        menuGuardar.gameObject.SetActive(true); 
    }

    // Función para abrir el menú de opciones
    public void opciones(){
        menuPausa.gameObject.SetActive(false);
        menuOpciones.gameObject.SetActive(true);
    }

    // Función para abrir el menú finalizar juego
    public void salir(){
        menuPausa.gameObject.SetActive(false);
        menuVolverAMain.gameObject.SetActive(false);        
        menuConfirmarSalir.gameObject.SetActive(false);   
        menuSalir.gameObject.SetActive(true);
    }

    // Función para abrir el menú de opciones y cerrar los demás
    public void volver(){
        menuPausa.gameObject.SetActive(true);
        menuGuardar.gameObject.SetActive(false);
        menuOpciones.gameObject.SetActive(false);
        menuSalir.gameObject.SetActive(false);
    }

    // Función para abrir el menú de volver a main
    public void volverMain() {
        menuSalir.gameObject.SetActive(false);
        menuVolverAMain.gameObject.SetActive(true); 
    }

    // Función para abrir el menú de confirmar salir
    public void confirmarSalir() {
        menuSalir.gameObject.SetActive(false);
        menuConfirmarSalir.gameObject.SetActive(true);        
    }

    // Función para cerrar el juego
    public void quit(){
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }

    // Función para volver al menú principal
    public void menuPrincipal(){
        Time.timeScale = 1;
        GameManager.instance.musica.Stop();
        Destroy(GameManager.instance.musica);
        Destroy(GameManager.instance.sonido);
        fade.gameObject.SetActive(true);
    }

    // Guardar partida
    public void guardar(string partida){
        // Nombre de la partida
        string nombrePartida = "Partida" + partida;

        // Establecer partida como guardada
        PlayerPrefs.SetString(nombrePartida, "set");

        // Guardar datos
        PlayerPrefs.SetInt(nombrePartida + "VidaJ1", GameManager.instance.vidaJ1);
        PlayerPrefs.SetInt(nombrePartida + "VidaMaxJ1", GameManager.instance.vidaMaxJ1);
        PlayerPrefs.SetInt(nombrePartida + "VelocidadJ1", GameManager.instance.velJ1);
        PlayerPrefs.SetString(nombrePartida + "Escena", escena);
        PlayerPrefs.SetFloat(nombrePartida + "PosicionX", jugador.transform.position.x);
        PlayerPrefs.SetFloat(nombrePartida + "PosicionY", jugador.transform.position.y);
        foreach (KeyValuePair<string, bool> combate in GameManager.instance.terminados) {
            PlayerPrefs.SetString(nombrePartida + combate.Key, combate.Value.ToString());
        }

        // Cerrar ventana
        menuGuardar.gameObject.SetActive(false);
        reanudar();
    }

    // Reproducir sonidos
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
