using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    // The build index of the next level to unlock
    public int nextLevelIndex; 

    public void NextLevel()
    {
        // Save bone count for this level
        int boneCount = PlayerStats.instance.GetCurrentBones();
        int highScore = PlayerPrefs.GetInt("Level_" + (SceneManager.GetActiveScene().buildIndex - 1) + "_HighScore", 0);
        if (boneCount > highScore)
        {
            PlayerPrefs.SetInt("Level_" + (SceneManager.GetActiveScene().buildIndex - 1) + "_HighScore", boneCount);
            PlayerPrefs.Save();
            // Update high score variable
            highScore = boneCount; 
        }
        // Unlock the next level
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        // If the completed level is the current level reached
        if (SceneManager.GetActiveScene().buildIndex - 1 == levelReached) 
        {
            // Increment levelReached to unlock the next level
            PlayerPrefs.SetInt("levelReached", levelReached + 1); 

            // Update state of game objects based on completed level
            if (levelReached == 1)
            {
                // Hide Hidewhenlevel1won
                PlayerPrefs.SetInt("Level1Won", 1); 
            }
            else if (levelReached == 2)
            {
                // Hide Hidewhenlevel1won
                PlayerPrefs.SetInt("Level2Won", 1); 
            }

            PlayerPrefs.Save();
        }

    }
}
