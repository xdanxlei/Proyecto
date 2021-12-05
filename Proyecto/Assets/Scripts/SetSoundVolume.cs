using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetSoundVolume : MonoBehaviour
{
    public AudioMixer  mixer; // Assign in inspector

    // Fijar volumen de la música
    public void SetLevel(float sliderValue)
    {
        if (sliderValue == 0){
            mixer.SetFloat("SoundVol", -80);
        } else {
            mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
        }

        // Guardar preferencias
        PlayerPrefs.SetString("VolumenSonido", sliderValue.ToString());
    }
}
