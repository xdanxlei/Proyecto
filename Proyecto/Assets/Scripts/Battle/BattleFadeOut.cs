using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFadeOut : MonoBehaviour
{
    
    // Nombre de la escena game over
    private string GAME_OVER = "Game Over";

    // Música
    public AudioClip musica;

    // Volver a la escena mapa
    public void Victoria()
    {
        // Marcar combate como terminado
        GameManager.instance.terminados["Mapa1Combate1"] = true;

        // Volver a la escena mapa
        SceneManager.UnloadSceneAsync("Combate_1");
        GameManager.instance.escena.gameObject.SetActive(true);
        GameManager.instance.faderEscena.gameObject.SetActive(true);
        GameManager.instance.animatorEscena.gameObject.SetActive(true);
            
        // Cambiar música
        GameManager.instance.musica.clip = musica;

        // Reproducir música
        GameManager.instance.musica.Play();
    }

    // Ir a la escena Game Over
    public void Derrota()
    {
        SceneManager.LoadScene(GAME_OVER, LoadSceneMode.Single);
    }
}
