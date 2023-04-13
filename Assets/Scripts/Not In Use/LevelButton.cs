using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public class LevelButton : MonoBehaviour
//{

//    public int levelIndex; // The index of the level
//    public Image medalIcon; // The image component to display the medal icon

//    public Sprite bronzeMedalSprite; // The bronze medal icon
//    public Sprite silverMedalSprite; // The silver medal icon
//    public Sprite goldMedalSprite; // The gold medal icon

//    private void Start()
//    {
//        // Load and display high score for this level
//        int highScore = PlayerPrefs.GetInt("Level_" + (levelIndex + 1) + "_HighScore", 0);
//        Debug.Log("High score for level " + levelIndex + ": " + highScore);

//        // Set the medal icon based on the high score
//        if (highScore > 0 && highScore <= 10)
//        {
//            medalIcon.sprite = bronzeMedalSprite;
//        }
//        else if (highScore > 10 && highScore <= 30)
//        {
//            medalIcon.sprite = silverMedalSprite;
//        }
//        else if (highScore > 30)
//        {
//            medalIcon.sprite = goldMedalSprite;
//        }
//    }
//}