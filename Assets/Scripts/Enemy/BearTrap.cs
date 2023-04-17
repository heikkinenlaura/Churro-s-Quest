using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    // reference to the animator component
    private Animator animator;
    // Reference to the player's health script
    public PlayerHealth playerHealth;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Called when the player enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the trap
        if (other.gameObject.CompareTag("Player"))
        {
            // Subtract one life from the player
            playerHealth.DecreaseLives(1);

            animator.SetBool("isTrapped", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player collided with the trap
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTrapped", false);
        }
    }
}
