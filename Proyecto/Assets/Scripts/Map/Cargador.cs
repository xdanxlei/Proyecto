using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargador : MonoBehaviour
{
    // Jugador
    public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        // Cargar posición del jugador
        if (GameManager.instance.cargar) {
            GameManager.instance.cargar = false;
            jugador.transform.position = new Vector3(GameManager.instance.x, GameManager.instance.y, 0);
        }
    }
}
