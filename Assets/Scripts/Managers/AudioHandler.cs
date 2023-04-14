using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    //public AudioClip playerWalkingSound;
    public AudioClip collectItemSound;
    public AudioClip collectCoinSound;
    public AudioClip loseLifeSound;
    public AudioClip getLifeSound;
    public AudioClip backgroundMusic;
    public AudioClip buttonPressedSound;
    public AudioClip barkSound;

    private AudioSource audioSource;
    private AudioSource backgroundMusicSource;

    private void Awake()
    {
        // Get the main audio source
        audioSource = GetComponent<AudioSource>();

        // Create a new audio source for the background music
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    //public void PlayPlayerWalkingSound()
    //{
    //    audioSource.clip = playerWalkingSound;
    //    audioSource.Play();
    //}
    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("No audio clip provided to PlaySound function.");
            return;
        }

        audioSource.PlayOneShot(clip);
    }
    public void PlayBarkSound()
    {
        PlaySound(barkSound);
    }

    public void PlayCollectPowerUpSound()
    {
        PlaySound(collectItemSound);
    }
    public void PlayCollectCoinSound()
    {
        PlaySound(collectCoinSound);
    }

    public void PlayLoseLifeSound()
    {
        PlaySound(loseLifeSound);
    }

    public void PlayGetLifeSound()
    {
        PlaySound(getLifeSound);
    }

    public void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayButtonPressedSound()
    {
        PlaySound(buttonPressedSound);
    }

}