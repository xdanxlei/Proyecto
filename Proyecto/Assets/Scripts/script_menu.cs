using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class script_menu : MonoBehaviour
{
    public GameObject  menu; // Assign in inspector
    public GameObject  menuOpciones; // Assign in inspector
    public GameObject  menuSalir; // Assign in inspector
    public AudioSource musica; // Assign in inspector
    public AudioSource sonido; // Assign in inspector
    public AudioClip botonEn; // Assign in inspector
    public AudioClip botonPos; // Assign in inspector
    public AudioClip botonNeg; // Assign in inspector

    // Start is called before the first frame update
    void Start()
    {
        musica.Play();
    }

    // Función para abrir el menú de opciones
    public void opciones(){
        menu.gameObject.SetActive(false);
        menuOpciones.gameObject.SetActive(true);
    }

    // Función para abrir el menú de opciones
    public void salir(){
        menu.gameObject.SetActive(false);
        menuSalir.gameObject.SetActive(true);
    }

    public void volver(){
        menu.gameObject.SetActive(true);
        menuOpciones.gameObject.SetActive(false);
        menuSalir.gameObject.SetActive(false);
    }

    public void quit(){
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }

    public void botonEnter(){
        sonido.PlayOneShot(botonEn);
    }

    public void botonPositive(){
        sonido.PlayOneShot(botonPos);
    }

    public void botonNegative(){
        sonido.PlayOneShot(botonNeg);        
    }

    public void nuevaPartida(){
        SceneManager.LoadScene("Primer mapa", LoadSceneMode.Single);
    }

    public void cargarPartida(){

    }
}
