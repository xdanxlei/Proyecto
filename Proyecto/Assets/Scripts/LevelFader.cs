using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader : MonoBehaviour
{
    // Fader
    public GameObject fader;

    // Cambiar mapa
    public void CambiarMapa (string mapa) { 
        // Ir al mapa
        SceneManager.LoadScene(mapa, LoadSceneMode.Single);
    }

    // Desactivar
    public void Desactivar () {
        fader.gameObject.SetActive(false);
    }
}
