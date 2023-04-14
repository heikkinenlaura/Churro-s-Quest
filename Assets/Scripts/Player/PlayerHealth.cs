using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerController instance;
    public int maxLives = 3;
    public int currentLives;
    public GameObject diePanel;
    public GameObject uiPanel;
    public Image[] hearts;
    public AudioHandler audioHandler;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;

        if (diePanel != null)
        {
            diePanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check for player death
        if (currentLives <= 0)
        {
            Die();
        }
    }

    // Method to handle player death
    void Die()
    {
        if (diePanel != null)
        {
            diePanel.SetActive(true);
            uiPanel.SetActive(false);
            Time.timeScale = 0; // freeze time
        }
    }

    // Method to decrease player lives
    public void DecreaseLives(int amount)
    {
        currentLives -= amount;

        // Update the UI to reflect the player's current lives
        for (int i = hearts.Length - 1; i >= currentLives; i--)
        {
            audioHandler.PlayLoseLifeSound();
            hearts[i].enabled = false;
        }
    }
    public void CollectFood()
    {
        IncreaseLives(1);
        // Update the UI to reflect the player's current lives

        for (int i = 0; i < currentLives; i++)
        {
            audioHandler.PlayGetLifeSound();
            hearts[i].enabled = true;
        }
    }

    // Method to increase player lives
    public void IncreaseLives(int amount)
    {
        currentLives += amount;

        // Ensure currentLives does not exceed maxLives
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }
    }
}