using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 45f; // The total time available for the level
    public TMP_Text timerText; // The UI text element that displays the timer
    public GameObject losePanel;

    private void Start()
    {
        UpdateTimerText(); // Update the timer text when the level starts
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Decrease the time remaining by the time since the last frame
            UpdateTimerText(); // Update the timer text
        }
        else
        {
            // The time has run out, trigger the level failed event
            Debug.Log("Time's up!");
            losePanel.SetActive(true); 
            timerText.text = "Time Remaining: 0";
            Time.timeScale = 0;
        }
    }

    private void UpdateTimerText()
    {
        // Format the time remaining as minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update the timer text
        timerText.text = "Time Remaining: " + timerString;
    }
}
