using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoneCollector : MonoBehaviour
{
    public int boneValue = 10;

    // Method to handle bone collection
    void Collect()
    {
        // Save bone count for this level
        int boneCount = PlayerStats.instance.GetCurrentBones();
        int highScore = PlayerPrefs.GetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), 0);
        if (boneCount > highScore)
        {
            PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), boneCount);
            PlayerPrefs.Save();
        }
        // Set high score equal to bone value
        highScore = boneValue;

        // For example, to increase the player's score by the boneValue:
        GameManager.instance.AddScore(boneValue);

        // Increment bone count
        PlayerStats.instance.BoneCount += 10;

        // Then, destroy the bone object:
        Destroy(gameObject);
    }

    // Method to handle collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object is the player
        if (other.CompareTag("Player"))
        {
            // Call the Collect method
            Collect();
        }
    }
}
