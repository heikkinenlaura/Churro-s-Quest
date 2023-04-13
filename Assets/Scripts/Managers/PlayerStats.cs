using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [SerializeField] private int maxBones = 0;
    [SerializeField] private int currentBones = 0;
    public int maxCoins = 0;
    private int currentCoins = 0;

    // Dictionary to store the high scores for each level
    public Dictionary<string, int> levelHighScores = new Dictionary<string, int>();

    public int BoneCount
    {
        get { return currentBones; }
        set { currentBones = value; }
    }
    public int CoinCount
    {
        get { return currentCoins; }
    }


    private void Awake()
    {
        // Ensure only one instance of this object exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } 
        // Load the saved coin count when the game starts
        currentCoins = PlayerPrefs.GetInt("CoinCount", 0);
    }
    public int GetCurrentBones()
    {
        return currentBones;
    }
    public void IncreaseBones(int amount)
    {
        currentBones += amount;
        if (currentBones > maxBones)
        {
            maxBones = currentBones;
        }
    }
    public void IncreaseCoins(int amount)
    {
        currentCoins += amount;
        if (currentCoins > maxCoins)
        {
            maxCoins = currentCoins;
        }
    }

    public void ResetBones()
    {
        currentBones = 0;
    }
    public void ResetCoins()
    {
        currentCoins = 0;
    }
    public void SetLevelHighScore(string levelName, int score)
    {
        if (levelHighScores.ContainsKey(levelName))
        {
            // If a high score already exists for this level, update it if the new score is higher
            if (score > levelHighScores[levelName])
            {
                levelHighScores[levelName] = score;
            }
        }
        else
        {
            // If a high score does not exist for this level, add it
            levelHighScores.Add(levelName, score);
        }

        // Save the high score to player preferences
        PlayerPrefs.SetInt(levelName + "_HighScore", score);
        PlayerPrefs.Save();
    }

    public int GetLevelHighScore(string levelName)
    {
        if (levelHighScores.ContainsKey(levelName))
        {
            return levelHighScores[levelName];
        }
        else
        {
            return 0;
        }
    }
    private void OnApplicationQuit()
    {
        // Save the coin count when the game ends
        PlayerPrefs.SetInt("CoinCount", currentCoins);
        PlayerPrefs.Save();
    }
}