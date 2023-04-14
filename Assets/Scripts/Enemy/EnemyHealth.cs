using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TMP_Text healthText; // Reference to the text element in the UI
    public Canvas canvas;


    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText(); // Update the health text when the enemy is spawned
    }
    void Update()
    {
        canvas.transform.position = transform.position;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthText(); // Update the health text whenever the enemy takes damage

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: Add death animation and/or sound effects
        Destroy(gameObject);
        healthText.text = " ";
    }

    private void UpdateHealthText()
    {
        healthText.text = " " + currentHealth; // Update the text to display the current health

    }
}