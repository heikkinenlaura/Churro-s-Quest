using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFriend : MonoBehaviour
{
    public float followDistance = 2f;

    private Transform player;
    private bool isFollowing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isFollowing)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > followDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFollowing = false;
        }
    }
}