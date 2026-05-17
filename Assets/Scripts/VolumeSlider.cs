using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        SetVolume("MasterVolume", masterSlider.value);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SetVolume("MusicVolume", musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        SetVolume("SFXVolume", sfxSlider.value);

        masterSlider.onValueChanged.AddListener(v => SetVolume("MasterVolume", v));
        musicSlider.onValueChanged.AddListener(v => SetVolume("MusicVolume", v));
        sfxSlider.onValueChanged.AddListener(v => SetVolume("SFXVolume", v));
    }

    private void SetVolume(string parameter, float value)
    {
        if (value < 0.001)
        {
            audioMixer.SetFloat(parameter, -80);
        }
        else
        {
            audioMixer.SetFloat(parameter, Mathf.Log10(value) * 20);
        }
        PlayerPrefs.SetFloat(parameter, value);
    }
}