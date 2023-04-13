using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth corgi = other.GetComponent<PlayerHealth>();
            if (corgi != null)
            {
                corgi.CollectFood();
                Destroy(gameObject);
            }
        }
    }
}