using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Constantes
    const string MENU_PRINCIPAL = "Main Menu";

    // Música
    public AudioClip musica;

    // Start is called before the first frame update
    void Start()
    {
        // Cambiar música
        GameManager.instance.musica.clip = musica;

        // Reproducir música
        GameManager.instance.musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Ir al menú principal
            Time.timeScale = 1;
            GameManager.instance.musica.Stop();
            Destroy(GameManager.instance.musica);
            Destroy(GameManager.instance.sonido);
            SceneManager.LoadScene(MENU_PRINCIPAL, LoadSceneMode.Single);
        } 
    }
}
