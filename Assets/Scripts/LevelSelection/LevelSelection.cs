using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons; // An array of all the level buttons on the level selection screen
    public Sprite lockedSprite; // The sprite to use for locked levels
    public Image[] medalIcons; // An array of all the medal icons on the level selection screen
    public Sprite bronzeMedalSprite; // The bronze medal icon
    public Sprite silverMedalSprite; // The silver medal icon
    public Sprite goldMedalSprite; // The gold medal icon
    public TMP_Text coinText; // The text object to display the coin count

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        // Load and display the coin count
        int coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        coinText.text = coinCount + " ";

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                // Set the button to be locked
                levelButtons[i].interactable = false;
                levelButtons[i].GetComponent<Image>().sprite = lockedSprite;
            }
            else
            {
                // Set the button to be unlocked
                levelButtons[i].interactable = true;
                // Load and display high score for this level
                int highScore = PlayerPrefs.GetInt("Level_" + (i + 1) + "_HighScore", 0);
                // Set the medal icon based on the high score
                if (highScore > 0 && highScore <= 10)
                {
                    medalIcons[i].sprite = bronzeMedalSprite;
                    Debug.Log(highScore + " should be bronze");
                }
                else if (highScore > 10 && highScore <= 30)
                {
                    medalIcons[i].sprite = silverMedalSprite;
                }
                else if (highScore > 30)
                {
                    medalIcons[i].sprite = goldMedalSprite;
                }
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);
    }
}