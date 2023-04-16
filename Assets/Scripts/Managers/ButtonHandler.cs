using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Button buttonToEnable;
    public GameObject notCollected;
    public GameObject collected;

    private void Start()
    {
        // Check if the GemCollected value is set
        if (PlayerPrefs.GetInt("GemCollected", 0) == 1)
        {
            // Enable the specified button
            buttonToEnable.interactable = true;

            collected.SetActive(true);
            notCollected.SetActive(false);
        }
        else
        {
            buttonToEnable.interactable = false;
        }
    }
    public void LoadExtraLevel()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
