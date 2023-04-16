using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    // Reference to the player's health script
    public PlayerHealth playerHealth;

    // Called when the player enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the trap
        if (other.gameObject.CompareTag("Player"))
        {
            // Subtract one life from the player
            playerHealth.DecreaseLives(1);

            // Destroy the trap
            //Destroy(gameObject);
        }
    }
}
