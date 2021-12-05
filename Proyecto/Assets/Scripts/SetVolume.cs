using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer  mixer; // Assign in inspector

    // Fijar volumen de la música
    public void SetLevel(float sliderValue)
    {
        if (sliderValue == 0){
            mixer.SetFloat("MusicVol", -80);
        } else {
            mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        }

        // Guardar preferencias
        PlayerPrefs.SetString("VolumenMusica", sliderValue.ToString());
    }
}
