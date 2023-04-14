using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    public float boostedSpeed = 10f; // the speed to set when the power-up is collected
    public float normalSpeed = 5f; // the speed to set after the boost duration
    public float boostDuration = 2f; // the duration of the speed boost in seconds
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

                // Start coroutine to set speed back to normalSpeed after boostDuration seconds
                StartCoroutine(ResetSpeed(player));

                audioHandler.PlayCollectPowerUpSound();
            }

            // Deactivate the power-up object
            gameObject.SetActive(false);
        }
    }

    IEnumerator ResetSpeed(PlayerController player)
    {
        // Wait for the boostDuration to end
        yield return new WaitForSeconds(boostDuration);

        // Set player's speed back to normalSpeed
        player.moveSpeed = normalSpeed;
    }
}