using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeGuardar : MonoBehaviour
{
    // Mensaje
    public GameObject mensaje;

    // Engranaje
    public GameObject gear;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            // Reanudar escena
            Time.timeScale = 1;
            gear.gameObject.SetActive(true);
            mensaje.gameObject.SetActive(false);
        } 
    }
}
