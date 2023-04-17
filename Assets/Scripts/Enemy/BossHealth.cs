using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    // reference to the animator component
    private Animator animator;

    // Reference to the panel to be displayed when the boss is defeated
    public GameObject winningPanel;

    // Delay before displaying the winning panel
    public float winDelay = 2f; 

    public LevelComplete levelComplete;

    private void Start()
    {
        // Set the current health to the maximum health when the object is created
        currentHealth = maxHealth;
        animator = transform.GetChild(1).GetComponent<Animator>();
    }

    // Function to decrease the health by a specified amount
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the health has dropped to zero or below
        if (currentHealth <= 0)
        {
            // Call the Die function 
            Die();
        }
    }

    // Function to handle the death of the wall
    private void Die()
    {
        animator.SetTrigger("isBreaking");

        transform.GetChild(0).gameObject.SetActive(false);
        // Display the winning panel after a delay
        Invoke("ShowWinningPanel", winDelay);
    }

    private void ShowWinningPanel()
    {
        winningPanel.SetActive(true);
        levelComplete.NextLevel();
    }
}