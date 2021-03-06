﻿using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityValue)
    {
        QualitySettings.SetQualityLevel(qualityValue);
    }

    public void SetVsyncLevel(int vsyncValue)
    {
        QualitySettings.vSyncCount = vsyncValue;
    }
}
