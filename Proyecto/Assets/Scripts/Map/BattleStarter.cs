using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStarter : MonoBehaviour
{
    // Starter
    public GameObject starter;

    // Objetos a parar
    public GameObject escena;

    // Cambiar nivel
    public void CambiarNivel(string nivel)
    {
        // Ir al mapa
        SceneManager.LoadScene(nivel, LoadSceneMode.Additive);
        starter.gameObject.SetActive(false);
        escena.gameObject.SetActive(false);
    }
}
