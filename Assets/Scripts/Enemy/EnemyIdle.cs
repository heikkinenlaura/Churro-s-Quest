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

    private enum State { Idle, Follow };
    private State currentState;

    private bool facingRight;

    private void Start()
    {
        startingPosition = transform.position;
        animator = GetComponent<Animator>();
        currentState = State.Idle;
    }

    private void Update()
    {
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
        if (playerTransform && Vector2.Distance(playerTransform.position, transform.position) < detectDistance)
        {
            animator.SetBool("IsRunning", true);
            currentState = State.Follow;
        }
        Flip();
    }

    private void FollowPlayer()
    {
        if (playerTransform)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(playerTransform.position, transform.position) > detectDistance)
            {
                animator.SetBool("IsRunning", false);
                currentState = State.Idle;
            }
            Flip();
        }
    }
    private void Flip()
    {
        if (playerTransform)
        {
            if (transform.position.x < playerTransform.position.x && !facingRight)
            {
                facingRight = true;
                transform.localScale = new Vector3(-5, 5, 5);
            }
            else if (transform.position.x > playerTransform.position.x && facingRight)
            {
                facingRight = false;
                transform.localScale = new Vector3(5, 5, 5);
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
            currentState = State.Idle;

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
