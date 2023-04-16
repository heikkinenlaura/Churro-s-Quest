using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    // the speed to set when the power-up is collected
    public float boostedSpeed = 10f;
    // the speed to set after the boost duration
    public float normalSpeed = 5f;
    // the duration of the speed boost in seconds
    public float boostDuration = 2f; 
    public AudioHandler audioHandler;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {

                // Set player's speed to boostedSpeed
                player.moveSpeed = boostedSpeed;
                audioHandler.PlayCollectPowerUpSound();
            }

            // Deactivate the power-up object
            gameObject.SetActive(false);
        }
    }
}