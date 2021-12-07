using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena_1 : MonoBehaviour
{
    // Objetos
    public GameObject menuPausa;
    public GameObject menuGuardar;
    public GameObject menuOpciones;
    public GameObject menuSalir;
    public GameObject menuVolverAMain;
    public GameObject menuConfirmarSalir;
    public GameObject gear;
    public GameObject combate;

    // Sonidos
    public AudioClip botonPos;
    public AudioClip botonNeg;

    public void Start()
    {
        // Destruir combate si está derrotado
        if(GameManager.instance.terminados.ContainsKey("Mapa1Combate1")){
            if(GameManager.instance.terminados["Mapa1Combate1"]){
                combate.gameObject.SetActive(false);
            }
        }
    }

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
                menuGuardar.gameObject.SetActive(false);
                menuOpciones.gameObject.SetActive(false);
                menuSalir.gameObject.SetActive(false);
                menuVolverAMain.gameObject.SetActive(false);
                menuConfirmarSalir.gameObject.SetActive(false);
                GameManager.instance.sonido.PlayOneShot(botonPos);
            }
        }
    }
}
