using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollectable : MonoBehaviour
{
    public int gemValue = 1; // The number of gems to add when collected

    // Method called when the player collides with the gem
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add the gem value to the player's total gems
            GameManager.instance.AddGems(gemValue);

            // Save a value to indicate that the gem has been collected
            PlayerPrefs.SetInt("GemCollected", 1);
            PlayerPrefs.Save();

            // Destroy the gem object
            Destroy(gameObject);
        }
    }
}