using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireExtinguisher : MonoBehaviour
{
    public TMP_Text extinguishedFiresText;

    // The number of fires that need to be extinguished to complete the level
    public int requiredFiresCount = 10;

    public LevelComplete levelComplete;

    // Reference to the panel that displays the extinguished fires count
    public GameObject firePanel;

    // Reference to the panel to be displayed when the level is completed
    public GameObject winningPanel;

    // The number of fires that have been extinguished
    private static int extinguishedFiresCount = 0;

    public PlayerHealth player;

    private void Start()
    {
        // Updates the extinguished fires count text when the game starts
        UpdateExtinguishedFiresCountText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Damage the player's health if the enemy collides with them
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.DecreaseLives(1);
            }
        }
    }

    // Updates the extinguished fires count text with the current number of extinguished fires
    private void UpdateExtinguishedFiresCountText()
    {
        extinguishedFiresText.text = "Fires Extinguished: " + extinguishedFiresCount.ToString() + "/" + requiredFiresCount.ToString();
    }

    // Shows the winning panel and advances to the next level
    private void ShowWinningPanel()
    {
        firePanel.SetActive(false);
        winningPanel.SetActive(true);
        levelComplete.NextLevel();
    }

    // Public method to be called when the animation collides with the fire
    public void ExtinguishFire()
    {
        extinguishedFiresCount++;
        UpdateExtinguishedFiresCountText();

        // If the required amount of fires has been extinguished, show the winning panel
        if (extinguishedFiresCount >= requiredFiresCount)
        {
            ShowWinningPanel();
        }

        // Destroy the fire object
        Destroy(gameObject);
    }
}