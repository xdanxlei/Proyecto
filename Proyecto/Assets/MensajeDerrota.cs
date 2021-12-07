using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MensajeDerrota : MonoBehaviour
{
    // Nombre de la escena game over
    private string GAME_OVER = "Game Over";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Ir a la escena Game Over
            SceneManager.LoadScene(GAME_OVER, LoadSceneMode.Single);
        } 
    }
}
