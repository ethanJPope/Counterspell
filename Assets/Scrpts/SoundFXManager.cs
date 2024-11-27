using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager: MonoBehaviour
{
    public static SoundFXManager instance;
    public AudioSource soundFXSource;
    public AudioSource musicSource;
    public AudioClip background;

    private void Start() {
        musicSource.clip = background;
        musicSource.Play();
    }
    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform pos, float volume) {
        AudioSource audioSource = Instantiate(soundFXSource, pos.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
