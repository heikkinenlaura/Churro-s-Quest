using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    // The amount of coins the player receives for collecting this coin
    public int coinValue = 10;
    public AudioHandler audioHandler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the coin
        if (other.CompareTag("Player")) 
        {
            // Increase the coin count in PlayerStats
            PlayerStats.instance.IncreaseCoins(coinValue); 

            // Increase the coin count in the GameManager
            GameManager.instance.AddCoins(coinValue);

            audioHandler.PlayCollectCoinSound();

            // Destroy the coin object
            Destroy(gameObject); 
        }
    }
}