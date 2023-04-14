using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;

    public GameObject winningPanel; // Reference to the panel to be displayed when the boss is defeated
    public float winDelay = 2f; // Delay before displaying the winning panel

    public LevelComplete levelComplete;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current health: " + currentHealth); // Debug the current health


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: Play an animation that shows the wall breaking.
        // TODO: Add a delay to allow the animation to finish playing.
        // TODO: Show a winning panel to indicate that the player has won the level.

        // Disable the boss enemy object
        gameObject.SetActive(false);

        // Display the winning panel after a delay
        Invoke("ShowWinningPanel", winDelay);
    }

    private void ShowWinningPanel()
    {
        winningPanel.SetActive(true);
        levelComplete.NextLevel();
    }
}