using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonPressedSound;
    private void Awake()
    {
        // Get the main audio source
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayButtonPressedSound()
    {
        audioSource.clip = buttonPressedSound;
        audioSource.Play();
    }
}
