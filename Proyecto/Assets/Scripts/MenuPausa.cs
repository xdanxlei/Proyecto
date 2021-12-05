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
    const string MENU_PRINCIPAL = "Main Menu";
    const string KEY_MUSICA = "VolumenMusica";
    const string KEY_SONIDO = "VolumenSonido";

    // Objetos
    public GameObject  menuPausa;
    public GameObject  menuOpciones;
    public GameObject  menuSalir;
    public GameObject  menuVolverAMain;
    public GameObject  menuConfirmarSalir;
    public GameObject  gear;

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
        if (PlayerPrefs.HasKey(KEY_MUSICA)){
            musica.value = (float) Convert.ToDouble(PlayerPrefs.GetString(KEY_MUSICA));
        }
        if (PlayerPrefs.HasKey(KEY_SONIDO)){
            sonido.value = (float) Convert.ToDouble(PlayerPrefs.GetString(KEY_SONIDO));
        }
    }

    // Función para volver al juego
    public void reanudar(){
        // Reanudar escena
        Time.timeScale = 1;
        menuPausa.gameObject.SetActive(false);
        gear.gameObject.SetActive(true);
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
        GameManager.instance.musica.Stop();
        SceneManager.LoadScene(MENU_PRINCIPAL, LoadSceneMode.Single);
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
