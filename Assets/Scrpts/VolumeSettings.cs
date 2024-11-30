using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider SFXSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

    public void Start()
    {
    float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);
    float sfxVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.75f);

    volumeSlider.SetValueWithoutNotify(musicVolume);
    SFXSlider.SetValueWithoutNotify(sfxVolume);

    UpdateVolume();
    UpdateSFX();
    }


    public void UpdateVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void UpdateSFX()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
        PlayerPrefs.Save();
    }
}
