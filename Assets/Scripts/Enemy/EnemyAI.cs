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

    public enum State { Patrol, Follow }

    public State currentState;

    private void Start()
    {
        startingPosition = transform.position;
        currentPatrolDistance = patrolDistance;

        // Set the initial state to patrol
        currentState = State.Patrol;
    }

    private void Update()
    {
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
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x > startingPosition.x + currentPatrolDistance)
            {
                transform.localScale = new Vector3(-5, 5, 5); // Flip the sprite to face left
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x < startingPosition.x - currentPatrolDistance)
            {
                transform.localScale = new Vector3(5, 5, 5); // Flip the sprite to face right
                movingRight = true;
            }
        }

        if (playerTransform && Vector2.Distance(playerTransform.position, transform.position) < detectDistance)
        {
            currentState = State.Follow;
            followTimer = followDuration;
        }
    }

    private void FollowPlayer()
    {
        if (playerTransform)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            followTimer -= Time.deltaTime;

            if (Vector2.Distance(playerTransform.position, transform.position) > detectDistance || followTimer <= 0)
            {
                currentState = State.Patrol;
                currentPatrolDistance = patrolDistance;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = null;
            currentState = State.Patrol; // Go back to patrol state when player exits trigger

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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