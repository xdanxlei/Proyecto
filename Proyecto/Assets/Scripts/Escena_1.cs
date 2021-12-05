using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena_1 : MonoBehaviour
{
    // Objetos
    public GameObject  menuPausa;
    public GameObject  gear;

    // Sonidos
    public AudioClip botonPos;
    public AudioClip botonNeg;

    // Update is called once per frame
    public void Update()
    {
       // Al pulsar escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuPausa.gameObject.activeSelf){
                // Reanudar escena
                Time.timeScale = 1;

                // Desactivar menú
                menuPausa.gameObject.SetActive(false);
                gear.gameObject.SetActive(true);
                GameManager.instance.sonido.PlayOneShot(botonNeg);
            } else {
                // Pausar escena
                Time.timeScale = 0;

                // Activar menú
                menuPausa.gameObject.SetActive(true);
                gear.gameObject.SetActive(false);
                GameManager.instance.sonido.PlayOneShot(botonPos);
            }
        }
    }
}
