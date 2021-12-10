using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Música
    public AudioClip musica;

    // Fade
    public Animator fade;

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
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            // Ir al menú principal
            Time.timeScale = 1;
            GameManager.instance.musica.Stop();
            Destroy(GameManager.instance.musica);
            Destroy(GameManager.instance.sonido);
            fade.SetTrigger("FadeOut");
        } 
    }
}
