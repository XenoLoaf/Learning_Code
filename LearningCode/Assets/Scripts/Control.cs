using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Control : MonoBehaviour
{
    public AudioMixer mixer;

    void Update()
    {
        if (Input.GetKeyDown("["))
        {
            mixer.SetFloat ("MusicVolume", -80f);
            print ("Mute");
        }

            if (Input.GetKeyDown("]"))
        {
            mixer.SetFloat ("MusicVolume", 0.0f);
            print ("Unmute");
        }
    }


}

//    mixer.SetFloat ("MusicVolume", Mathf.Log10 (sliderValue) * 20 );
