using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float detectDistance = 5.0f;

    private Transform playerTransform;
    private Vector3 startingPosition;
    private Animator animator;

    // Define an enum to keep track of the current state of the Enemy
    private enum State { Idle, Follow };
    private State currentState;

    private bool facingRight;

    private void Start()
    {
        // Store the starting position of the enemy
        startingPosition = transform.position;

        animator = GetComponent<Animator>();

        // Set the initial state to idle
        currentState = State.Idle;

        transform.localScale = new Vector3(-1, 1, 1);
        gameObject.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
    }

    private void Update()
    {
        // Depending on the current state of the enemy, call the corresponding method
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Follow:
                FollowPlayer();
                break;
        }
    }

    private void Idle()
    {
        // Check if player is within detect distance and transition to follow state if true
        if (playerTransform && Vector2.Distance(playerTransform.position, transform.position) < detectDistance)
        {
            animator.SetBool("IsRunning", true);
            currentState = State.Follow;
        }
        // Flip the sprite if necessary
        Flip();
    }

    private void FollowPlayer()
    {
        if (playerTransform)
        {
            // Move towards the player's position
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

            // If the player is outside of the detect distance, transition to idle state
            if (Vector2.Distance(playerTransform.position, transform.position) > detectDistance)
            {
                animator.SetBool("IsRunning", false);
                currentState = State.Idle;
            }
            // Flip the sprite if necessary
            Flip();
        }
    }
    private void Flip()
    {
        if (playerTransform)
        {
            // If the player is to the right of the enemy and the enemy is facing left, flip the sprite
            if (transform.position.x < playerTransform.position.x && !facingRight)
            {
                facingRight = true;
                transform.localScale = new Vector3(1, 1, 1);

                gameObject.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
            }
            // If the player is to the left of the enemy and the enemy is facing right, flip the sprite
            else if (transform.position.x > playerTransform.position.x && facingRight)
            {
                facingRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
                gameObject.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Set the player transform when entering the player's trigger zone
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Set the player transform to null and go back to patrol state when leaving the player's trigger zone
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = null;
            currentState = State.Idle;
            animator.SetBool("IsRunning", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Damage the player's health if the enemy collides with them
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.DecreaseLives(1);
            }
        }
    }
}
