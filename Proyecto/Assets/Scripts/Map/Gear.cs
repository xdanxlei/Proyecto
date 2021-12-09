using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    // Objetos
    public GameObject menuPausa;
    public GameObject gear;

    // Update is called once per frame
    public void GearClick()
    {
        // Pausar escena
        Time.timeScale = 0;

        // Activar menú
        gear.gameObject.SetActive(false);
        menuPausa.gameObject.SetActive(true);
    }
}
