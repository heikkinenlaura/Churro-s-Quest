using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // static reference to the GameManager instance
    public int score = 0; // player's score
    public int coinCount; // The current number of coins collected by the player
    public int gemCount; // The current number of gems collected by the player
    public int highScore; // The high score for the current level

    // Awake is called before Start
    void Awake()
    {
        // Check if an instance of GameManager already exists
        if (instance == null)
        {
            // If not, set the instance to this object
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    // Method to add score
    public void AddScore(int amount)
    {
        score += amount;
    }

    // Method to increase the player's coin count
    public void AddCoins(int amount)
    {
        coinCount += amount;
    }

    // Method to increase the player's gem count
    public void AddGems(int amount)
    {
        gemCount += amount;
    }
}