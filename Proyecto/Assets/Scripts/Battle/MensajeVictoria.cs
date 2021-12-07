using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MensajeVictoria : MonoBehaviour
{
    // Música
    public AudioClip musica;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Marcar combate como terminado
            GameManager.instance.terminados["Mapa1Combate1"] = true;

            // Volver a la escena mapa
            SceneManager.UnloadSceneAsync("Combate_1");
            GameManager.instance.escena.gameObject.SetActive(true);
                
            // Cambiar música
            GameManager.instance.musica.clip = musica;

            // Reproducir música
            GameManager.instance.musica.Play();
        } 
    }
}
