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
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        masterSlider.onValueChanged.AddListener(v => SetVolume("MasterVolume", v));
        musicSlider.onValueChanged.AddListener(v => SetVolume("MusicVolume", v));
        sfxSlider.onValueChanged.AddListener(v => SetVolume("SFXVolume", v));
    }

    private void SetVolume(string parameter, float value)
    {
        audioMixer.SetFloat(parameter, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(parameter, value);
    }
}