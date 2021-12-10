using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeVictoria : MonoBehaviour
{    
    // Mensaje
    public GameObject mensaje;

    // Animator
    public Animator fadeOut;
    public GameObject fadeOutObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            mensaje.gameObject.SetActive(false);
            fadeOutObject.gameObject.SetActive(true);
            fadeOut.SetTrigger("Victoria");
        } 
    }
}
