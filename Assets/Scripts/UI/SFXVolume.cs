using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXVolume : MonoBehaviour
{
    public Slider Slider;
    public AudioMixer AudioMixer;

    public void SetSFXVolume()
    {
        AudioManager.Instance.PlaySFX("Choose");
        float value = Slider.value;
        AudioMixer.SetFloat("SFX", value);
    }
}
