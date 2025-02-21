using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolumne : MonoBehaviour
{
    public AudioMixer myMixer;
    public Slider musicSlider;

    public void SetMusicVolumne()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", musicSlider.value);
    }
}
