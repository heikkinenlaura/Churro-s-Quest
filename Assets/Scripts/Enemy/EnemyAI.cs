using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float patrolDistance = 2.0f;
    public float detectDistance = 5.0f;
    public float followDuration = 3.0f;

    private float currentPatrolDistance;
    private bool movingRight = true;
    private Transform playerTransform;
    private Vector3 startingPosition;
    private float followTimer;

    // Define an enum to keep track of the current state of the Enemy
    public enum State { Patrol, Follow }

    public State currentState;

    private void Start()
    {
        // Store the starting position of the enemy
        startingPosition = transform.position;

        // Set the current patrol distance to the initial patrol distance
        currentPatrolDistance = patrolDistance;

        // Set the initial state to patrol
        currentState = State.Patrol;
    }

    private void Update()
    {
        // Depending on the current state of the enemy, call the corresponding method
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;

            case State.Follow:
                FollowPlayer();
                break;
        }
    }

    private void Patrol()
    {
        // If the enemy is moving right, translate it to the right
        if (movingRight)
        {
            // If the enemy has reached the end of its patrol distance, flip it to face left and start moving left
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x > startingPosition.x + currentPatrolDistance)
            {
                // Flip the sprite to face left
                transform.localScale = new Vector3(-5, 5, 5); 
                movingRight = false;
            }
        }
        // If the enemy is moving left, translate it to the left
        else
        {
            // If the enemy has reached the end of its patrol distance, flip it to face right and start moving right
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x < startingPosition.x - currentPatrolDistance)
            {
                // Flip the sprite to face right
                transform.localScale = new Vector3(5, 5, 5); 
                movingRight = true;
            }
        }

        // If the player is within the detect distance, switch to the follow state
        if (playerTransform && Vector2.Distance(playerTransform.position, transform.position) < detectDistance)
        {
            currentState = State.Follow;
            followTimer = followDuration;
        }
    }

    private void FollowPlayer()
    {
        // Follow the player's position
        if (playerTransform)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            followTimer -= Time.deltaTime;

            // Go back to patrol state if the player is out of range or if the follow timer is up
            if (Vector2.Distance(playerTransform.position, transform.position) > detectDistance || followTimer <= 0)
            {
                currentState = State.Patrol;
                currentPatrolDistance = patrolDistance;
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
            // Go back to patrol state when player exits trigger
            currentState = State.Patrol; 
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