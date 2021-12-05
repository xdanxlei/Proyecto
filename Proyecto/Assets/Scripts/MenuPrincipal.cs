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

    // Objetos
    public GameObject  menu;
    public GameObject  menuOpciones;
    public GameObject  menuSalir;

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

        // Reproducir música
        GameManager.instance.musica.Play();
    }

    // Función para abrir el menú de opciones
    public void opciones(){
        menu.gameObject.SetActive(false);
        menuOpciones.gameObject.SetActive(true);
    }

    // Función para abrir el menú finalizar juego
    public void salir(){
        menu.gameObject.SetActive(false);
        menuSalir.gameObject.SetActive(true);
    }

    // Función para abrir el menú de opciones y cerrar los demás
    public void volver(){
        menu.gameObject.SetActive(true);
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

    public void botonEnter(){
        GameManager.instance.sonido.PlayOneShot(botonEn);
    }

    public void botonPositive(){
        GameManager.instance.sonido.PlayOneShot(botonPos);
    }

    public void botonNegative(){
        GameManager.instance.sonido.PlayOneShot(botonNeg);        
    }

    public void nuevaPartida(){
        SceneManager.LoadScene(PRIMER_MAPA, LoadSceneMode.Single);
    }

    public void cargarPartida(){

    }
}
