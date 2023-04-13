using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinValue = 1; // The amount of coins the player receives for collecting this coin
    public AudioHandler audioHandler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player has collided with the coin
        {
            PlayerStats.instance.IncreaseCoins(coinValue); // Increase the coin count in PlayerStats
            GameManager.instance.AddCoins(coinValue); // Increase the coin count in the GameManager
            audioHandler.PlayCollectCoinSound();
            Destroy(gameObject); // Destroy the coin object
        }
    }
}