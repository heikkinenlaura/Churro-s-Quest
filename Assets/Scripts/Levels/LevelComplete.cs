using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public int nextLevelIndex; // The build index of the next level to unlock

    public void NextLevel()
    {
        // Save bone count for this level
        int boneCount = PlayerStats.instance.GetCurrentBones();
        int highScore = PlayerPrefs.GetInt("Level_" + (SceneManager.GetActiveScene().buildIndex - 1) + "_HighScore", 0);
        if (boneCount > highScore)
        {
            PlayerPrefs.SetInt("Level_" + (SceneManager.GetActiveScene().buildIndex - 1) + "_HighScore", boneCount);
            PlayerPrefs.Save();
            highScore = boneCount; // Update high score variable
        }
        // Unlock the next level
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        if (SceneManager.GetActiveScene().buildIndex - 1 == levelReached) // If the completed level is the current level reached
        {
            PlayerPrefs.SetInt("levelReached", levelReached + 1); // Increment levelReached to unlock the next level
            PlayerPrefs.Save();
        }

    }
}
