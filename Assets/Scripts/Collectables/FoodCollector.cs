using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    public AudioHandler audioHandler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding gameobject has the tag "Player"
        if (other.CompareTag("Player"))
        {    
            // Get the PlayerHealth component attached to the player gameobject
            PlayerHealth corgi = other.GetComponent<PlayerHealth>();

            // Check if the PlayerHealth component was successfully obtained
            if (corgi != null)
            {
                audioHandler.PlayCollectPowerUpSound();
                // Call the CollectFood method of the PlayerHealth component to increment the food count
                corgi.CollectFood();

                // Destroy the gameobject that this script is attached to
                Destroy(gameObject);
            }
        }
    }
}